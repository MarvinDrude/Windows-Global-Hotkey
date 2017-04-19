using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base.Hotkeys {
    public class HotkeyManager {

        public Dictionary<ushort, HotkeyAction> Hotkeys { get; }
        public Dictionary<Job, ushort> Jobs { get; }
        public bool Active { get; set; }

        private HotkeyForm form;

        public HotkeyManager () {

            Active = true;
            Jobs = new Dictionary<Job, ushort>();
            Hotkeys = new Dictionary<ushort, HotkeyAction>();

            form = new HotkeyForm();
            form.HotkeyPressed += HotkeyPressed;

        }

        private void HotkeyPressed (object sender, HotkeyEventArgs args) {

            if (Active) {

                HotkeyAction ha = Hotkeys[args.id];

                if (ha != null) {

                    if (ha.Active) {

                        Thread t = new Thread(() => ha.Execute());
                        t.IsBackground = true;
                        t.Start();

                    }

                }

            }

        }

        public bool RegisterHotkey (Job job, HotkeyAction ha) {

            if (ha != null) {

                if (ha.Hotkey.Status != Hotkey.HotkeyStatus.Registered &&
                    ha.Hotkey.IsValid) {

                    form.RegisterHotkey(ha.Hotkey);

                    if (ha.Hotkey.Status == Hotkey.HotkeyStatus.Registered) {

                        Jobs.Add(job, ha.Hotkey.ID);
                        Hotkeys.Add(ha.Hotkey.ID, ha);
                        return true;

                    }

                }

            }

            return false;

        }

        public bool UnregisterHotkey (Job job) {

            HotkeyAction ha = Hotkeys[Jobs[job]];

            if (ha.Hotkey.Status == Hotkey.HotkeyStatus.Registered) {

                form.UnregisterHotkey(ha.Hotkey);

                if (ha.Hotkey.Status == Hotkey.HotkeyStatus.None) {

                    Hotkeys.Remove(ha.Hotkey.ID);
                    Jobs.Remove(job);
                    return true;

                }

            }

            return false;

        }
        

        public void UnregisterAllHotkeys () {

            Job[] vals = (Job[])Enum.GetValues(typeof(Job));

            foreach (Job job in vals) {

                UnregisterHotkey(job);

            }

        }

        public enum Job {

            Save,
            Close,
            Screenshot

        }

    }
}
