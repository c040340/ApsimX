﻿using Models.Core;
using Models.CLEM.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CLEM.Groupings
{
	///<summary>
	/// Contains a group of filters to identify individual other animals
	///</summary> 
	[Serializable]
	[ViewName("UserInterface.Views.GridView")]
	[PresenterName("UserInterface.Presenters.PropertyPresenter")]
    [Description("This other animal filter group selects specific individuals from the other animals using any number of Other Animal Filters.")]
    public class OtherAnimalsFilterGroup: CLEMModel
	{
		[Link]
		private ResourcesHolder Resources = null;

		/// <summary>
		/// Daily amount to supply selected individuals each month
		/// </summary>
		[Description("Daily amount to supply selected individuals each month")]
		public double[] MonthlyValues { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		public OtherAnimalsFilterGroup()
		{
			MonthlyValues = new double[12];
		}

		/// <summary>
		/// name of other animal type
		/// </summary>
		[Description("Name of other animal type")]
		public string AnimalType { get; set; }

		/// <summary>
		/// The Other animal type this group points to
		/// </summary>
		public OtherAnimalsType SelectedOtherAnimalsType;

		/// <summary>An event handler to allow us to initialise ourselves.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		[EventSubscribe("Commencing")]
		private void OnSimulationCommencing(object sender, EventArgs e)
		{
			SelectedOtherAnimalsType = Resources.OtherAnimalsStore().GetByName(AnimalType) as OtherAnimalsType;
			if(SelectedOtherAnimalsType == null)
			{
				throw new Exception("Unknown other animal type: " + AnimalType + " in OtherAnimalsActivityFeed : " + this.Name);
			}
		}

	}
}
