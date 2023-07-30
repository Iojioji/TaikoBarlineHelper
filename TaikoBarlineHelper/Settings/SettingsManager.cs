using OsuParsers.Enums.Beatmaps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaikoBarlineHelper.Settings
{
    public delegate void NoteValueChanged(NoteSettings caller);
    public static class SettingsManager
    {
        static string _version;
        static string _loadedMap;
        static string _linesString;

        /// <summary>
        /// TODO: Decide how to organize individual note settings.
        /// </summary>
        static NoteSettings _donSettings;
        static NoteSettings _katSettings;
        static NoteSettings _donFinSettings;
        static NoteSettings _katFinSettings;

        static bool _isTutorial;

        public static string UpdateXML { get => Properties.Settings.Default.UpdateXML; }
        public static string Version { get => _version; set => _version = value; }
        public static string LoadedMap
        {
            get => _loadedMap;
            set
            {
                _loadedMap = value;
                Properties.Settings.Default.LoadedMap = _loadedMap;
                Properties.Settings.Default.Save();
            }
        }
        public static string LinesString
        {
            get => _linesString;
            set
            {
                _linesString = value;
                Properties.Settings.Default.LinesFieldString = _linesString;
                Properties.Settings.Default.Save();
            }
        }
        public static NoteSettings DonSettings
        {
            get => _donSettings;
            set
            {
                _donSettings = value;
            }
        }
        public static NoteSettings KatSettings
        {
            get => _katSettings;
            set
            {
                _katSettings = value;
            }
        }
        public static NoteSettings DonFinSettings
        {
            get => _donFinSettings;
            set
            {
                _donFinSettings = value;
            }
        }
        public static NoteSettings KatFinSettings
        {
            get => _katFinSettings;
            set
            {
                _katFinSettings = value;
            }
        }
        public static bool IsTutorial
        {
            get => _isTutorial;
            set
            {
                _isTutorial = value;
                Properties.Settings.Default.IsTutorial = _isTutorial;
                Properties.Settings.Default.Save();
            }
        }


        public static void Init()
        {
            _loadedMap = Properties.Settings.Default.LoadedMap;
            _linesString = Properties.Settings.Default.LinesFieldString;
            _isTutorial = Properties.Settings.Default.IsTutorial;

            _donSettings = new NoteSettings()
            {
                Note = TaikoNote.Don,
                GimmickType = (GimmickType)Properties.Settings.Default.DonSetGimmickType,

                Enabled = Properties.Settings.Default.DonSetEnabled,
                BarlineAmount = Properties.Settings.Default.DonSetBarAmount,
                BarlineSpacing = Properties.Settings.Default.DonSetBarSpacing,
                BarlineSVIncrease = Properties.Settings.Default.DonSetBarSVIncrease,
            };
            _katSettings = new NoteSettings()
            {
                Note = TaikoNote.Kat,
                Enabled = Properties.Settings.Default.KatSetEnabled,
                GimmickType = (GimmickType)Properties.Settings.Default.KatSetGimmickType,

                BarlineAmount = Properties.Settings.Default.KatSetBarAmount,
                BarlineSpacing = Properties.Settings.Default.KatSetBarSpacing,
                BarlineSVIncrease = Properties.Settings.Default.KatSetBarSVIncrease,
            };
            _donFinSettings = new NoteSettings()
            {
                Note = TaikoNote.DonFinisher,
                Enabled = Properties.Settings.Default.DonFinSetEnabled,
                GimmickType = (GimmickType)Properties.Settings.Default.DonFinSetGimmickType,

                BarlineAmount = Properties.Settings.Default.DonFinSetBarAmount,
                BarlineSpacing = Properties.Settings.Default.DonFinSetBarSpacing,
                BarlineSVIncrease = Properties.Settings.Default.DonFinSetBarSVIncrease,
            };
            _katFinSettings = new NoteSettings()
            {
                Note = TaikoNote.KatFinisher,
                Enabled = Properties.Settings.Default.KatFinSetEnabled,
                GimmickType = (GimmickType)Properties.Settings.Default.KatFinSetGimmickType,

                BarlineAmount = Properties.Settings.Default.KatFinSetBarAmount,
                BarlineSpacing = Properties.Settings.Default.KatFinSetBarSpacing,
                BarlineSVIncrease = Properties.Settings.Default.KatFinSetBarSVIncrease,
            };

            SetNoteEvents();
        }

        static string GetNoteSettingName(NoteSettings toGet)
        {
            switch (toGet.Note)
            {
                case TaikoNote.Don:
                    return "DonSet";
                case TaikoNote.Kat:
                    return "KatSet";
                case TaikoNote.DonFinisher:
                    return "DonFinSet";
                case TaikoNote.KatFinisher:
                    return "KatFinSet";
                default:
                    return "";
            }
        }

        #region NoteSettingsEvents
        static void SetNoteEvents()
        {
            _donSettings.OnNoteValueChanged += OnNoteSettingsValueChanged;
            _katSettings.OnNoteValueChanged += OnNoteSettingsValueChanged;
            _donFinSettings.OnNoteValueChanged += OnNoteSettingsValueChanged;
            _katFinSettings.OnNoteValueChanged += OnNoteSettingsValueChanged;
        }
        private static void OnNoteSettingsValueChanged(NoteSettings caller)
        {
            string noteName = GetNoteSettingName(caller);

            Properties.Settings.Default[$"{noteName}Enabled"] = caller.Enabled;
            Properties.Settings.Default[$"{noteName}GimmickType"] = (int)caller.GimmickType;
            Properties.Settings.Default[$"{noteName}BarAmount"] = caller.BarlineAmount;
            Properties.Settings.Default[$"{noteName}BarSpacing"] = caller.BarlineSpacing;
            Properties.Settings.Default[$"{noteName}BarSVIncrease"] = caller.BarlineSVIncrease;

            Properties.Settings.Default.Save();

        }
        #endregion
    }

    public class NoteSettings
    {
        bool _enabled = false;
        GimmickType _gimmickType = GimmickType.Barline; 

        int _barlineAmount = 1;
        int _barlineSpacing = 1;
        decimal _barlineSVIncrease = 0;
        TaikoNote _note;

        NoteValueChanged _onNoteValueChanged;

        public TaikoNote Note { get => _note; set => _note = value; }
        public NoteValueChanged OnNoteValueChanged { get => _onNoteValueChanged; set => _onNoteValueChanged = value; }

        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                _onNoteValueChanged?.Invoke(this);
            }
        }
        public GimmickType GimmickType
        {
            get => _gimmickType;
            set
            {
                _gimmickType = value;
                _onNoteValueChanged?.Invoke(this);
            }
        }
        public int BarlineAmount
        {
            get => _barlineAmount;
            set
            {
                _barlineAmount = value;
                _onNoteValueChanged?.Invoke(this);
            }
        }
        public int BarlineSpacing
        {
            get => _barlineSpacing;
            set
            {
                _barlineSpacing = value;
                _onNoteValueChanged?.Invoke(this);
            }
        }
        public decimal BarlineSVIncrease
        {
            get => _barlineSVIncrease;
            set
            {
                _barlineSVIncrease = value;
                _onNoteValueChanged?.Invoke(this);
            }
        }
    }
}