using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;


[assembly: CommandClass(typeof(AC_Utils.Class1));

namespace AC_Utils
{
	public class Class1
	{
		//Put your AutoCAD command here
		[CommandMethod("acCommand")]
		public void AcCommand()
		{
			// Get the current document and database, start a transaction
			Document acDoc = Application.DocumentManager.MdiActiveDocument;
			Database acCurDb = acDoc.Database;

			// Start a transaction with the Transaction Manager
			using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
			{
				// Body of transaction goes here
			}
		}
	}
}
