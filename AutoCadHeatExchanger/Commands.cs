using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoCadHeatExchanger.AutocadOptions;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AutoCadHeatExchanger
{
    public class Commands
    {
        private Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
        private Database db = Application.DocumentManager.MdiActiveDocument.Database;



        [CommandMethod("HelloWord")]
        public void HellowWorld()
        {
            ed.WriteMessage("Hello world");
        }

        [CommandMethod("AddLayer")]
        public void AddLayers()
        {
            LayerManager.AddLayer("StubColumn", Color.Green);
            LayerManager.AddLayer("TopColumn", Color.Blue);
            LayerManager.AddLayer("SidePanel", Color.Coral);
            LayerManager.AddLayer("FanRing", Color.Lime);
            LayerManager.AddLayer("KneeBraceClip", Color.DarkOrange);
            LayerManager.AddLayer("KneeBrace", Color.SkyBlue);
        }

        [CommandMethod("ShowForm")]
        public void ShowForm()
        {
            AddLayers();
            WpfWindow form = new WpfWindow();
            Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowModelessWindow(form);
        }
    }
}
