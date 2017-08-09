using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Colors;


// [assembly: CommandClass(typeof(AC_Utils.Layer_Utils))]

namespace AC_Utils
{
	public static class Layer_Utils
	{
		public static bool LayerExist(String Layer)
		{
			bool layerE = false;
			// Get the current document and database, start a transaction
			Document acDoc = Application.DocumentManager.MdiActiveDocument;
			Database acCurDb = acDoc.Database;

			// Start a transaction with the Transaction Manager
			using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
			{
				LayerTable acLayerTable = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;
				if(acLayerTable.Has(Layer))
				{
					layerE = true;
				}
				acTrans.Dispose();
			}
			return layerE;
		}

		public static void CreateLry(string lryName)
		{
			// Get the current document and database, start a transaction
			Document acDoc = Application.DocumentManager.MdiActiveDocument;
			Database acCurDb = acDoc.Database;

			using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
			{
				LayerTable acLryTbl;
				acLryTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;

				if (acLryTbl.Has(lryName) == false)
				{
					using (LayerTableRecord aclryTblRec = new LayerTableRecord())
					{
						aclryTblRec.Name = lryName;

						// Upgrade the layer table for write
						acLryTbl.UpgradeOpen();

						//Append the new layer to the layer table and the tracaction
						acLryTbl.Add(aclryTblRec);
						acTrans.AddNewlyCreatedDBObject(aclryTblRec, true);
					}
				}
				acTrans.Commit();
			}
		}
		// Overload method for CreateLry adding a color parameter
		public static void CreateLry(string lryName, short colorNo)
		{
			// Get the current document and database, start a transaction
			Document acDoc = Application.DocumentManager.MdiActiveDocument;
			Database acCurDb = acDoc.Database;

			using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
			{
				LayerTable acLryTbl;
				acLryTbl = acTrans.GetObject(acCurDb.LayerTableId, OpenMode.ForRead) as LayerTable;

				if (acLryTbl.Has(lryName) == false)
				{
					using (LayerTableRecord aclryTblRec = new LayerTableRecord())
					{
						aclryTblRec.Name = lryName;
						aclryTblRec.Color = Color.FromColorIndex(ColorMethod.ByAci, colorNo);

						// Upgrade the layer table for write
						acLryTbl.UpgradeOpen();

						//Append the new layer to the layer table and the tracaction
						acLryTbl.Add(aclryTblRec);
						acTrans.AddNewlyCreatedDBObject(aclryTblRec, true);
					}
				}
				acTrans.Commit();
			}
		}
	}
}
