using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TaikoBarlineHelper.Settings;
using OsuParsers.Beatmaps.Objects.Taiko;
using OsuParsers.Enums.Beatmaps;

namespace TaikoBarlineHelper.Gimmicks
{
    public class GimmickHandler
    {
        Beatmap? _loadedBeatmap;
        Beatmap? _backupMap;
        List<TimingPoint> _backupTimingPoints;

        public Beatmap LoadedBeatmap { get => _loadedBeatmap; set => _loadedBeatmap = value; }
        public Beatmap BackupMap { get => _backupMap; set => _backupMap = value; }

        public void MakeGimmick((int, int) points)
        {

        }
        [Obsolete]
        public void MakeGimmick(string[] lines)
        {
            if (_loadedBeatmap == null)
            {
                return;
            }

            _backupMap = CloneBeatmap(_loadedBeatmap);

            foreach (string line in lines)
            {
                LookForThing(line);
            }

            Debug.WriteLine($"Saving Map!");
            _loadedBeatmap.Save(SettingsManager.LoadedMap);
        }

        public void RevertChanges()
        {
            _backupMap?.Save(SettingsManager.LoadedMap);
            _backupMap = null;
            _backupTimingPoints.Clear();
        }

        Beatmap CloneBeatmap(Beatmap toClone)
        {
            _backupTimingPoints = toClone.TimingPoints.ToList();
            Beatmap beatmap = new Beatmap()
            {
                GeneralSection = toClone.GeneralSection,
                EditorSection = toClone.EditorSection,
                MetadataSection = toClone.MetadataSection,
                DifficultySection = toClone.DifficultySection,
                EventsSection = toClone.EventsSection,
                ColoursSection = toClone.ColoursSection,
                TimingPoints = _backupTimingPoints,
                HitObjects = toClone.HitObjects,
            };

            return beatmap;
        }

        void LookForThing(string timingLine)
        {
            string targetTimingPoint = timingLine;
            string barlineMSString = targetTimingPoint.Split(',')[0];

            if (string.IsNullOrEmpty(barlineMSString) || string.IsNullOrWhiteSpace(barlineMSString))
            {
                return;
            }

            int barlineMS = -1;
            int.TryParse(barlineMSString, out barlineMS);

            if (barlineMS == -1)
            {
                return;
            }

            TimingPoint currentPoint = null;
            TimingPoint lastRedline = null;

            currentPoint = _loadedBeatmap.TimingPoints.Find(x => x.Offset == barlineMS && x.BeatLength < 0);

            if (currentPoint == null)
            {
                Debug.WriteLine($"No such point as {barlineMS}");
                return;
            }

            foreach (TimingPoint tp in _loadedBeatmap.TimingPoints)
            {
                //bool isTarget = tp.Offset == barlineMS;
                bool isRedline = tp.BeatLength >= 0;

                if (isRedline)
                {
                    if (tp.Offset <= barlineMS)
                    {
                        lastRedline = tp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (lastRedline == null)
            {
                Debug.WriteLine($"No redline lmao {barlineMS}");
                return;
            }

            GenerateBarlines(currentPoint, lastRedline);
            Debug.WriteLine($"TP {currentPoint.Offset} -> {barlineMS}\r\n  SV: {currentPoint.BeatLength}\r\n");
        }
        TaikoHit GetNoteInOffset(int offset)
        {
            TaikoHit hitObject = null;
            foreach (HitObject ho in _loadedBeatmap.HitObjects)
            {
                if (ho.StartTime != offset)
                    continue;

                TaikoHit? hit = ho as TaikoHit;
                if (hit != null)
                {
                    hitObject = hit;
                    break;
                }
            }
            return hitObject;
        }

        #region Barlines
        bool ShouldAddBarline(TaikoHit hit)
        {
            bool result = false;

            if (hit.IsBig)
            {
                if (hit.Color == TaikoColor.Blue)
                {
                    result = SettingsManager.KatFinSettings.Enabled;
                }
                else
                {
                    result = SettingsManager.DonFinSettings.Enabled;
                }
            }
            else
            {
                if (hit.Color == TaikoColor.Blue)
                {
                    result = SettingsManager.KatSettings.Enabled;
                }
                else
                {
                    result = SettingsManager.DonSettings.Enabled;
                }
            }

            return result;
        }

        void GenerateBarlines(TimingPoint origin, TimingPoint lastRedline)
        {
            if (origin == null)
            {
                //TODO: Tell user wtf are you doing lmao
                return;
            }
            if (lastRedline == null)
            {
                //TODO: uuuh, no previous redline wtf
                return;
            }


            double svValue = -100 / origin.BeatLength;
            double bpm = 60000 / lastRedline.BeatLength;
            int originalOffset = origin.Offset;
            TaikoHit note = GetNoteInOffset(originalOffset);

            if (note == null)
            {
                return;
            }

            bool isKiai = (int)origin.Effects == 9 || origin.Effects == Effects.Kiai;

            if (!ShouldAddBarline(note))
            {
                return;
            }

            if (!SettingsManager.IsTutorial)
            {
                GenerateBarline(originalOffset, 10000, 10, origin.TimeSignature, origin.SampleSet, origin.CustomSampleSet, origin.Volume, isKiai, true);
            }

            NoteSettings noteSettings;
            if (note.IsBig)
            {
                if (note.Color == TaikoColor.Blue)
                {
                    noteSettings = SettingsManager.KatFinSettings;
                }
                else
                {
                    noteSettings = SettingsManager.DonFinSettings;
                }
            }
            else
            {
                if (note.Color == TaikoColor.Blue)
                {
                    noteSettings = SettingsManager.KatSettings;
                }
                else
                {
                    noteSettings = SettingsManager.DonSettings;
                }
            }
            GenerateBarlines(origin, bpm, isKiai, noteSettings.BarlineAmount, noteSettings.BarlineSpacing, (double)noteSettings.BarlineSVIncrease);

            //_loadedBeatmap.TimingPoints.Add(centerRedline);
            if (!SettingsManager.IsTutorial)
            {
                _loadedBeatmap.TimingPoints.Remove(origin);
            }

            _loadedBeatmap.TimingPoints = _loadedBeatmap.TimingPoints.OrderBy(x => x.Offset).ToList();

            //_loadedBeatmap.Save(SettingsManager.LoadedMap);
        }
        void GenerateBarlines(TimingPoint origin, double bpm, bool isKiai, int extraBarlines, int offsetIncrease, double svIncrease)
        {
            double svValue = -100 / origin.BeatLength;
            int originalOffset = origin.Offset;

            for (int i = 0; i < extraBarlines; i++)
            {
                int barOffset = 1 + (i * offsetIncrease);
                double svOffset = (i * svIncrease);

                GenerateBarline(originalOffset + barOffset, bpm, svValue + svOffset, origin.TimeSignature, origin.SampleSet, origin.CustomSampleSet, origin.Volume, isKiai, false);
                GenerateBarline(originalOffset - barOffset, bpm, svValue - svOffset, origin.TimeSignature, origin.SampleSet, origin.CustomSampleSet, origin.Volume, isKiai, false);
            }
        }
        void GenerateBarline(int offset, double bpm, double sv, TimeSignature timeSignature, SampleSet sampleSet, int customSampleSet, int volume, bool kiai, bool omitFirstBarline)
        {
            int redlineEffects = 0;
            if (kiai)
                redlineEffects += 1;
            if (omitFirstBarline)
                redlineEffects += 8;

            TimingPoint redline = new TimingPoint()
            {
                Offset = offset,
                BeatLength = 60000 / bpm,
                TimeSignature = timeSignature,
                SampleSet = sampleSet,
                CustomSampleSet = customSampleSet,
                Volume = volume,
                Inherited = false,
                Effects = (Effects)redlineEffects
            };

            TimingPoint greenline = new TimingPoint()
            {
                Offset = offset,
                BeatLength = -100 / sv,
                TimeSignature = timeSignature,
                SampleSet = sampleSet,
                CustomSampleSet = customSampleSet,
                Volume = volume,
                Inherited = true,
                Effects = (Effects)redlineEffects
            };

            _loadedBeatmap.TimingPoints.Add(redline);
            _loadedBeatmap.TimingPoints.Add(greenline);
        }
        #endregion

    }
}