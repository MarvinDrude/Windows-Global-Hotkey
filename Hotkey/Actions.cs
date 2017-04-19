using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PixiColor.Base.Hotkey.HotkeyManager;

namespace PixiColor.Base.Hotkey {
    public static class Actions {

        public static Dictionary<Job, Action> jobActions = new Dictionary<Job, Action>();

        public static void Add (Job job, Action action) {

            jobActions.Add(job, action);

        }

        public static Action Get (Job job) {

            return jobActions[job];

        }

    }
}
