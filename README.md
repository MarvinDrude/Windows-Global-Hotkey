# Windows-Global-Hotkey
Easy way of registering and unregistering global hotkeys for you c# program.

Usage (Change Job Enum to your needs):

´´´C#

HotkeyManager hm = new HotkeyManager();

Keys key = Keys.W | Keys.Control;
key.Win = true;

Hotkey hotkey = new Hotkey(key);

Action action = new Action(() => {
  Debug.WriteLine("Control + Win + W pressed");
});

HotkeyAction ha = new HotkeyAction(hotkey, action);

hm.RegisterHotkey(Job.Save, ha);

hm.UnregisterHotkey(Job.Save);

hm.UnregisterAllHotkeys();

´´´
