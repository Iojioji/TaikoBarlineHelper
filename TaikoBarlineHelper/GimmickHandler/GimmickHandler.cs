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
    enum TaikoObjectType { None = 0, TimingPoint = 1, Note = 2, Slider = 3, Spinner = 4 }
    public class GimmickHandler
    {
        Beatmap? _loadedBeatmap;
        Beatmap? _backupMap;
        List<TimingPoint> _backupTimingPoints;

        public Beatmap LoadedBeatmap { get => _loadedBeatmap; set => _loadedBeatmap = value; }
        public Beatmap BackupMap { get => _backupMap; set => _backupMap = value; }

        public void MakeGimmick(List<string> lines)
        {
            if (_loadedBeatmap == null)
            {
                return;
            }

            (TaikoObjectType type, List<string> lines) cleanedLines = CleanLines(lines);
            //return;

            if (cleanedLines.type == TaikoObjectType.None)
            {
                return;
            }

            _backupMap = CloneBeatmap(_loadedBeatmap);

            //TODO: Instead of making all the thing here, make LookForNote return a list of objects to affect and THEN do the thing.
            foreach (string line in cleanedLines.lines)
            {
                if (cleanedLines.type == TaikoObjectType.TimingPoint)
                {
                    //Do lines only.
                    LookForNote(line);
                }
                else
                {
                    //TODO: Do notes only
                }
            }

            Debug.WriteLine($"Saving Map!");
            _loadedBeatmap.Save(SettingsManager.LoadedMap);
        }

        public void RevertChanges()
        {
            _backupMap.Save(SettingsManager.LoadedMap);
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

        /// <summary>
        /// Cleans the lines to keep only affectable elements
        /// </summary>
        /// <param name="lines">The lines to clean</param>
        /// <returns>Only returns the lines that can be affected by barlines (TimingPoints or normal notes)</returns>
        (TaikoObjectType type, List<string> line) CleanLines(List<string> lines)
        {
            (TaikoObjectType type, List<string> lines) result = (TaikoObjectType.None, new List<string>());
            //List<(TaikoObjectType type, string line)> cleanedLines = new List<(TaikoObjectType type, string line)>();
            
            int index = 0;
            //TaikoObjectType currentObjectType = TaikoObjectType.None;
            Debug.WriteLine($"Checking {lines.Count} lines!");
            foreach (string line in lines)
            {
                List<string> splitLines = new List<string>();
                splitLines.AddRange(line.Split(','));

                if (splitLines.Count > 8)
                {
                    Debug.WriteLine($"   [Line {index}] [{line}] is invalid due to number of fields! ({splitLines.Count})");
                    index++;
                    continue;
                }

                bool isTimingPoint = splitLines.Count == 8 && !line.Contains(':');
                bool isNote = splitLines.Count == 6;
                bool isSlider = splitLines.Count == 8 && line.Contains('|');
                //bool isSpinner = splitLines.Count == 7;

                string type = isTimingPoint ? "TimingPoint" : (isNote ? "Note" : (isSlider ? "Slider" : "Spinner"));
                TaikoObjectType objectType = isTimingPoint ? TaikoObjectType.TimingPoint : (isNote ? TaikoObjectType.Note : (isSlider ? TaikoObjectType.Slider : TaikoObjectType.Spinner));

                if (objectType == TaikoObjectType.Spinner || objectType == TaikoObjectType.Slider)
                {
                    continue;
                }

                if (result.type != TaikoObjectType.None && result.type != objectType)
                {
                    MessageBox.Show($"Please don't mix objects in the text field (Only use TimingPoints or only use HitObjects)");
                    return (TaikoObjectType.None, new List<string>());
                }

                if (objectType == TaikoObjectType.TimingPoint || objectType == TaikoObjectType.Note)
                {
                    result.lines.Add(line);
                    result.type = objectType;
                }

                //Debug.WriteLine($"[Line {index}], [{line}] - [{splitLines.Count}] - [Timing? {isTimingPoint}], [Note? {isNote}], [Spinner? {isSpinner}], [Slider? {isSlider}]");
                Debug.WriteLine($"   [Line {index}], [{line}] - [{splitLines.Count}] - [{type}]");
                index++;
            }

            string finalResult = $"\r\n\r\nFinished results:\r\n";

            foreach (string line in result.lines)
            {
                finalResult += $"   {line}\r\n";
            }

            Debug.WriteLine($"{finalResult}");

            //return cleanedLines;
            return result;
        }

        void LookForNote(string timingLine)
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