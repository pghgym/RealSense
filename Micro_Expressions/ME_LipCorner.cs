﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace RealSense
{
    /*
     *@author Marlon
     * 
     * Problem besteht noch bei weit offenen Mund, keine Unterscheidung mehr zwischen Runter und Hoch why is that german ? 

     * Lip Corner down does not work so far, landmarkpoints at the lip corner are not tracked when they go down,
     * no further sdk settings found, maybe recognize patterns via opencv?
     */
    class ME_LipCorner : RSModule
    {
        // Variables for logic

        private double[] LipCorner = new double[2];


        // Variables for debugging

        // Default values
        public ME_LipCorner()
        {
            DEF_MIN = 0;
            DEF_MAX = 5;
            reset();
            MIN_TOL = -1;
            MAX_TOL = 0.5;
            debug = true;
            XTREME_MAX = 45;
            XTREME_MIN = -36;
        }

        public override void Work(Graphics g)
        {
            /* Calculations */

            // calculates difference between nose and LipCorner 
            LipCorner[0] = -((model.Difference(33, 26)) - 100);  //left LipCorner
            LipCorner[1] = -((model.Difference(39, 26)) - 100);  //right LipCorner

            LipCorner[0] = LipCorner[0] < MAX_TOL && LipCorner[0] > MIN_TOL ? 0 : LipCorner[0];
            LipCorner[1] = LipCorner[1] < MAX_TOL && LipCorner[1] > MIN_TOL ? 0 : LipCorner[1];

            LipCorner[0] = filterExtremeValues(LipCorner[0]);
            LipCorner[1] = filterExtremeValues(LipCorner[1]);

            dynamicMinMax(LipCorner);

            double[] diffs = convertValues(LipCorner);        

            // Update value in Model 
            model.setAU_Value(typeof(ME_LipCorner).ToString() + "_left", diffs[0]);
            model.setAU_Value(typeof(ME_LipCorner).ToString() + "_right", diffs[1]);

            // print debug-values 
            if (debug)
            {
                output = "LipCorner: "  + diffs[0] + ", " + diffs[1];
            }
        }
    }
}