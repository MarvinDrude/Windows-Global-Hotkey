using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base.Hotkeys {
    public class HotkeyEventArgs : EventArgs {

        public ushort id; 
        public Keys Key { get; set; }
        public Hotkey.Modifiers Mods { get; set; }

        public HotkeyEventArgs (ushort id, Keys key, Hotkey.Modifiers mods) {

            this.id = id;
            Key = key;
            Mods = mods;

        }

    }
}
