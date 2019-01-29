using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Bensonad
{
    public class GhcCentroid : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GhcCentroid class.
        /// </summary>
        public GhcCentroid()
          : base("GhcCentroid", "Center Points",
              "Gets the average center of a bunch of points",
              "Bad", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "Points", "Points", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Centroid", "Centroid", "Centroid", GH_ParamAccess.item);
            pManager.AddNumberParameter("Distances", "Distances", "Distances",GH_ParamAccess.list);
            pManager.AddCurveParameter("Lines", "Lines", "Lines", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Point3d> iPoints = new List<Point3d>();
            DA.GetDataList("Points", iPoints);

            Point3d centroid = new Point3d(0.0, 0.0, 0.0);

            foreach (Point3d Point in iPoints)
                centroid += Point;
            centroid = centroid / iPoints.Count;

            DA.SetData("Centroid", centroid);
            List<double> distances = new List<double>();
            List<Line> lines = new List<Line>();

            foreach (Point3d point in iPoints)
            {
                distances.Add(centroid.DistanceTo(point));
                lines.Add(new Line(centroid, point));
            }
                

            DA.SetDataList("Distances", distances);
            DA.SetDataList("Lines", lines);
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
                return Properties.Resources.Centroid;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("2ba23ebb-a0af-420d-99c2-586a7fd3896b"); }
        }
    }
}