﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace RealSense
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Model model = new Model();
            RSModule.Init(model);
            // Create modules beforehand
            model.AddModule(new FaceTrackerModule(null));
            model.AddModule(new AU_ScowledBrows_Tanja());
            model.AddModule(new ReadEmotionsTest_Tanja());
            /* 
             model.AddModule(new AU_LipsPressedModule_David());
             model.AddModule(new AU_EyelidTightModul_Anton());
             model.AddModule(new AU_LipsThicknessModul_Tobi());
             model.AddModule(new AU_MouthRect_Rene()); //Warum muss ich Modules.modulname schreiben?
             */
            //model.AddModule(new Gauge_Module_David());
            /*
            SurveillanceModule sm = new SurveillanceModule();
            sm.i();
            model.AddModule(sm);
            */
            Application.Run(new CameraView(model));
        }

    }
}
