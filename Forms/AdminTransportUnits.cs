using e_Shift.Business.Interface;
using e_Shift.Business.Services;
using e_Shift.Forms.TransportUnits;
using e_Shift.Repository.Interface;
using e_Shift.Repository.Services;
using System;
using System.Windows.Forms;

namespace e_Shift.Forms
{
    public partial class AdminTransportUnits : Form
    {
        public AdminTransportUnits()
        {
            InitializeComponent();
            this.Text = "Transport Units";
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            //IVehicleService vehicleService = new VehicleService(new VehicleRepository());
            //var vehicleForm = new Vehicles(vehicleService);
            //vehicleForm.Show();
            //this.Hide();
            ILorryRepository lorryRepository = new LorryRepository();
            ILorryService lorryService = new LorryService(lorryRepository);
            var vehiclesForm = new Vehicles(lorryService);
            vehiclesForm.Show();
            this.Close();
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            //IDriverService driverService = new DriverService(new DriverRepository());
            //var driversForm = new Drivers(driverService);
            //driversForm.Show();
            //this.Hide();
            IDriverRepository driverRepository = new DriverRepository();
            IDriverService driverService = new DriverService(driverRepository);
            var driversForm = new Drivers(driverService);
            driversForm.Show();
            this.Close();
        }

        private void btnAssistant_Click(object sender, EventArgs e)
        {
            // Instantiate the AssistantService with its dependency
            //IAssistantService assistantService = new AssistantService(new AssistantRepository());
            //var assistantsForm = new Assistants(assistantService);
            //assistantsForm.Show();
            //this.Hide();
            IAssistantRepository assistantRepository = new AssistantRepository();
            IAssistantService assistantService = new AssistantService(assistantRepository);
            var assistantsForm = new Assistants(assistantService);
            assistantsForm.Show();
            this.Hide();
        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            //IContainerService containerService = new ContainerService(new ContainerRepository());
            //var containersForm = new Containers(containerService);
            //containersForm.Show();
            //this.Hide();
            IContainerRepository containerRepository = new ContainerRepository();
            IContainerService containerService = new ContainerService(containerRepository);
            var containersForm = new Containers(containerService);
            containersForm.Show();
            this.Close();
        }
    }
}