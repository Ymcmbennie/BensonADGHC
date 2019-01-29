using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Bensonad
{
    public class GhcCreatePyramid : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GhcCreatePyramid class.
        /// </summary>
        public GhcCreatePyramid()
          : base("CreatePyramid", "Pyramid",
              "This creates a pyramid geometry",
              "Bad", "Geometry")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPlaneParameter("Base Plane", "Base Plane", "Base Plane", GH_ParamAccess.item);
            pManager.AddNumberParameter("Length", "Length", "Length", GH_ParamAccess.item);
            pManager.AddNumberParameter("Width", "Width", "Width", GH_ParamAccess.item);
            pManager.AddNumberParameter("Height", "Height", "Height", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("Display lines", "Display lines", "Display lines", GH_ParamAccess.list);
            pManager.AddPointParameter("Centroid", "Centroid", "Centroid", GH_ParamAccess.item);
            pManager.AddNumberParameter("Volume", "Volume", "Volume", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Plane basePlane = Plane.WorldXY;
            Double length = 1.0;
            Double height = 1.0;
            Double width = 1.0;

            DA.GetData("Base Plane", ref basePlane);
            DA.GetData("Length", ref length);
            DA.GetData("Width", ref width);
            DA.GetData("Height", ref height);


            //To pass pyramid as a class contructor make sure the pyramid source file has the same namespace

            Pyramid myPyramid = new Pyramid(basePlane, length, width, height);

            double volume = myPyramid.ComputeVolume();
            Point3d centroid = myPyramid.ComputeCentroid();
            List<LineCurve> pyramidCrv = myPyramid.ComputeDisplayLines();

            DA.SetDataList("Display lines", pyramidCrv);
            DA.SetData("Volume", volume);
            DA.SetData("Centroid", centroid);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.Pyramid;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("2d3fa8cf-b613-44a0-a957-b0f5a706dcc2"); }
        }
    }
}