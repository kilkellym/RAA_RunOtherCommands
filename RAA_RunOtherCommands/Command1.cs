namespace RAA_RunOtherCommands
{
	[Transaction(TransactionMode.Manual)]
	public class Command1 : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			// this is a variable for the Revit application
			UIApplication uiapp = commandData.Application;

			// this is a variable for the current Revit model
			Document doc = uiapp.ActiveUIDocument.Document;

			// Your code goes here
			TaskDialog.Show("Command 1", "This is Command 1");

			// Run Command2
			Command2 command2 = new Command2();
			command2.Execute(commandData, ref message, elements);

			// Run Command3
			Command3 command3 = new Command3();
			command3.Execute(commandData, ref message, elements);

			// Run Command4
			Command4 command4 = new Command4();
			command4.Execute(commandData, ref message, elements);

			return Result.Succeeded;
		}
		internal static PushButtonData GetButtonData()
		{
			// use this method to define the properties for this command in the Revit ribbon
			string buttonInternalName = "btnCommand1";
			string buttonTitle = "Button 1";
			string? methodBase = MethodBase.GetCurrentMethod().DeclaringType?.FullName;

			if (methodBase == null)
			{
				throw new InvalidOperationException("MethodBase.GetCurrentMethod().DeclaringType?.FullName is null");
			}
			else
			{
				Common.ButtonDataClass myButtonData1 = new Common.ButtonDataClass(
					buttonInternalName,
					buttonTitle,
					methodBase,
					Properties.Resources.Blue_32,
					Properties.Resources.Blue_16,
					"This is a tooltip for Button 1");

				return myButtonData1.Data;
			}
		}
	}

}
