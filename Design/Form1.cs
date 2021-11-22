using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Design.objects;
using Design.services;
using Microsoft.EntityFrameworkCore;

namespace Design
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }



        private void init()
        {
            dgvTableTypeOfItem_init();
            dgvTableTypeOfService_init();
            dgvTableTariff_init();
            dgvTableClients_init();
            dgvTableOrders_init();
            dgvTableEmployers_init();
        }

        private void dgvTableOrders_init()
        {
            using (var db = new DatabaseContext())
            {
                dgvTableOrders.Rows.Clear();

                foreach (var p in db.orders)
                {
                    dgvTableOrders.Rows.Add(new string[] { p.id.ToString(), p.client.name, p.typeOfServ.name, p.typeOfItem.name, p.timeOfReciept.ToString(), p.timeFit.ToString(), p.timeReady.ToString(), p.employer.name, p.prepaymant.ToString(), p.price.ToString() });
                }

            }
        }

        private void dgvTableClients_init()
        {
            using (var db = new DatabaseContext())
            {
                dgvTableClients.Rows.Clear();

                foreach (var p in db.clients)
                {
                    dgvTableEmployers.Rows.Add(new string[] { p.id.ToString(), p.name, p.phone.ToString(), p.size });
                    cmbClientOrder.Items.Add(p.name);
                }

            }
        }

        private void dgvTableEmployers_init()
        {
            using (var db = new DatabaseContext())
            {
                dgvTableEmployers.Rows.Clear();

                foreach (var p in db.employers)
                {
                    dgvTableEmployers.Rows.Add(new string[] { p.id.ToString(), p.name, p.position});
                    cmbEmployerOrder.Items.Add(p.name);
                }

            }
        }

        private void dgvTableTariff_init()
        {
            using (var db = new DatabaseContext())
            {
                dgvTableTariff.Rows.Clear();

                foreach (var p in db.tariffs)
                {
                    dgvTableTariff.Rows.Add(new string[] { p.id.ToString(), p.typeOfItem.name, p.typeOfService.name, p.price.ToString()});
                }

            }
        }


        private void dgvTableTypeOfService_init()
        {
            using (var db = new DatabaseContext())
            {
                dgvTableTypeOfService.Rows.Clear();

                foreach (var p in db.typeOfServices)
                {
                    dgvTableTypeOfService.Rows.Add(new string[] { p.id.ToString(), p.name });
                    cmbTypeOfServiceTariff.Items.Add(p.name);
                    cmbTypeOFService.Items.Add(p.name);
                    Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }
        }


        private void dgvTableTypeOfItem_init()
        {
            using (var db = new DatabaseContext())
            {
                dgvTableTypeOfItem.Rows.Clear();

                foreach (var p in db.typeOfItems)
                {
                    dgvTableTypeOfItem.Rows.Add(new string[] { p.id.ToString(), p.name });
                    cmbTypeOfItem.Items.Add(p.name);
                    cmbTypeOfItemTariff.Items.Add(p.name);
                    Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }
        }

        private void btnAddTypeOfItem_Click(object sender, EventArgs e)
        {
            //string name = txtNameTypeOfItem.Text;

            using (var db = new DatabaseContext())
            {

                var product = new TypeOfItem() { name = txtNameTypeOfItem.Text };
                db.typeOfItems.Add(product);
                db.SaveChanges();

                dgvTableTypeOfItem.Rows.Clear();
                
                foreach (var p in db.typeOfItems)
                {
                    dgvTableTypeOfItem.Rows.Add(new string[] { p.id.ToString(), p.name});
                    Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }
        }

        private void btnDeleteTypeOFItem_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new TypeOfItem() { id = Int32.Parse( dgvTableTypeOfItem.SelectedCells[0].Value.ToString()) };
                db.typeOfItems.Remove(product);
                db.SaveChanges();

                dgvTableTypeOfItem.Rows.Clear();

                foreach (var p in db.typeOfItems)
                {
                    dgvTableTypeOfItem.Rows.Add(new string[] { p.id.ToString(), p.name });
                    Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }

        }

        private void btnAddTypeOfService_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new TypeOfService() { name = txtNameTypeOfService.Text };
                db.typeOfServices.Add(product);
                db.SaveChanges();

                dgvTableTypeOfService.Rows.Clear();

                foreach (var p in db.typeOfServices)
                {
                    dgvTableTypeOfService.Rows.Add(new string[] { p.id.ToString(), p.name });
                    Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }
        }

        private void btnDeleteTypeOfService_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new TypeOfService() { id = Int32.Parse(dgvTableTypeOfService.SelectedCells[0].Value.ToString()) };
                db.typeOfServices.Remove(product);
                db.SaveChanges();

                dgvTableTypeOfService.Rows.Clear();

                foreach (var p in db.typeOfItems)
                {
                    dgvTableTypeOfService.Rows.Add(new string[] { p.id.ToString(), p.name });
                    Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }
        }

        private void btnAddTariff_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                TypeOfItem typeOfItem = null;
                foreach (var item in db.typeOfItems)
                {
                    if (item.name.Equals(cmbTypeOfItemTariff.SelectedItem.ToString()))
                    {
                        typeOfItem = item;
                    }
                }


                TypeOfService typeOFService = null;
                foreach (var item in db.typeOfServices)
                {
                    if (item.name.Equals(cmbTypeOfServiceTariff.SelectedItem.ToString()))
                    {
                        typeOFService = item;
                    }
                }

                var product = new Tariff() { typeOfItem = typeOfItem,
                                             typeOfService = typeOFService, 
                                             price = float.Parse(txtPriceTariff.Text)};
                db.tariffs.Add(product);
                db.SaveChanges();

                dgvTableTariff.Rows.Clear();

                foreach (var p in db.tariffs)
                {
                    dgvTableTariff.Rows.Add(new string[] { p.id.ToString(), p.typeOfItem.name, p.typeOfService.name, p.price.ToString() });
                    //Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }
        }

        private void btnDeleteTariff_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new Tariff() { id = Int32.Parse(dgvTableTariff.SelectedCells[0].Value.ToString()) };
                db.tariffs.Remove(product);
                db.SaveChanges();

                dgvTableTariff.Rows.Clear();

                foreach (var p in db.tariffs)
                {
                    dgvTableTariff.Rows.Add(new string[] { p.id.ToString(), p.typeOfItem.name, p.typeOfService.name, p.price.ToString() });
                    //Console.WriteLine("{0} {1} ", p.id, p.name);
                }

            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new Client() { name = txtNameClient.Text, phone = Int32.Parse(txtPhoneClient.Text), size = txtSizeClient.Text};
                db.clients.Add(product);
                db.SaveChanges();

                dgvTableClients.Rows.Clear();

                foreach (var p in db.clients)
                {
                    dgvTableClients.Rows.Add(new string[] { p.id.ToString(), p.name, p.phone.ToString(), p.size });
                }

            }
        }

        private void bntDeleteClient_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new Client() { id = Int32.Parse(dgvTableClients.SelectedCells[0].Value.ToString()) };
                db.clients.Remove(product);
                db.SaveChanges();

                dgvTableClients.Rows.Clear();

                foreach (var p in db.clients)
                {
                    dgvTableClients.Rows.Add(new string[] { p.id.ToString(), p.name, p.phone.ToString(), p.size });
                }

            }
        }

        private void btnAddEmployer_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new Employer() { name = txtNameEmployer.Text, position = txtPostionEmployer.Text };
                db.employers.Add(product);
                db.SaveChanges();

                dgvTableEmployers.Rows.Clear();

                foreach (var p in db.employers)
                {
                    dgvTableClients.Rows.Add(new string[] { p.id.ToString(), p.name, p.position, });
                }

            }
        }

        private void btnDeleteEmployer_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                var product = new Employer() { id = Int32.Parse(dgvTableClients.SelectedCells[0].Value.ToString()) };
                db.employers.Remove(product);
                db.SaveChanges();

                dgvTableEmployers.Rows.Clear();

                foreach (var p in db.employers)
                {
                    dgvTableClients.Rows.Add(new string[] { p.id.ToString(), p.name, p.position, });
                }

            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {

                TypeOfItem typeOfItem = null;
                foreach (var item in db.typeOfItems)
                {
                    if (item.name.Equals(cmbTypeOfItem.SelectedItem.ToString()))
                    {
                        typeOfItem = item;
                    }
                }


                TypeOfService typeOFService = null;
                foreach (var item in db.typeOfServices)
                {
                    if (item.name.Equals(cmbTypeOFService.SelectedItem.ToString()))
                    {
                        typeOFService = item;
                    }
                }

                Client client = null;
                foreach (var item in db.clients)
                {
                    if (item.name.Equals(cmbClientOrder.SelectedItem.ToString()))
                    {
                        client = item;
                    }
                }


                var product = new Order()
                {
                    typeOfItem = typeOfItem,
                    typeOfServ = typeOFService,
                    client = client,
                    timeOfReciept = DateTime.Now,
                    timeFit = dtpTimefitOrder.Value,
                    timeReady = dtpTimereadyOrder.Value,
                    prepaymant = float.Parse(txtPrepaymentOrder.Text),
                    price = float.Parse(txtPriceOrder.Text)
                };
                db.orders.Add(product);
                db.SaveChanges();

                dgvTableOrders.Rows.Clear();

                foreach (var p in db.orders)
                    dgvTableOrders.Rows.Add(new string[]
                    {
                        p.id.ToString(), p.client.name, p.typeOfServ.name, p.typeOfItem.name,
                        p.timeOfReciept.ToString(), p.timeFit.ToString(), p.timeReady.ToString(), p.employer.name,
                        p.prepaymant.ToString(), p.price.ToString()
                    });

            }
        }
    }
}
