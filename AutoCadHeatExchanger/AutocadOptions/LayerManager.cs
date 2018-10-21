using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AutoCadHeatExchanger.AutocadOptions
{
    public static class LayerManager
    {
        private static Database db = Application.DocumentManager.MdiActiveDocument.Database;

        public static void AddLayer(string layerName, System.Drawing.Color color)
        {
            using (Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    LayerTable layerTable;
                    LayerTableRecord layerTableRecord = new LayerTableRecord();

                    layerTable = (LayerTable)db.LayerTableId.GetObject(OpenMode.ForWrite);

                    layerTableRecord.Name = layerName;
                    layerTableRecord.Color = Color.FromRgb(color.R, color.G, color.B);

                    if (layerTable.Has(layerName) == false)
                    {
                        layerTable.Add(layerTableRecord);

                        trans.AddNewlyCreatedDBObject(layerTableRecord, true);

                        trans.Commit();
                    }

                    

                }
            }
        }

        public static void SetLayerCurrent(string LayerName)
        {
            // Get the current document and database
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            using (acDoc.LockDocument())
            {
                // Start a transaction
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    // Open the Layer table for read
                    LayerTable acLyrTbl;
                    acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId,
                                                    OpenMode.ForRead) as LayerTable;




                    if (acLyrTbl.Has(LayerName) == true)
                    {
                        // Set the layer Center current
                        acCurDb.Clayer = acLyrTbl[LayerName];

                        // Save the changes
                        acTrans.Commit();
                    }

                    // Dispose of the transaction
                }
            }

          
        }
    }
}
