﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koffiescanner
{
    public partial class Koffiescanner : Form
    {

        Scan scan = new Scan();

        public Koffiescanner()
        {
            InitializeComponent();
        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btFetchPlaces_Click(object sender, EventArgs e)
        {
            this.getPlaces();
        }

        private void btFetchLocations_Click(object sender, EventArgs e)
        {
            this.getCoffeeLocations();
        }

        private void top5OphalenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("no");
        }

        private async void getPlaces()
        {
            lvPlaces.Items.Clear();

            lstbxFeedback.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Plaatsen ophalen..");

            string url = "http://debestekoffievan.nl/";
            RequestPage request = new RequestPage();
            string response = await request.GetHTML(url);
            scan.fetchPlaces(response);

            foreach (var place in scan.places)
            {
                lvPlaces.Items.Add(new ListViewItem(new string[] { place.Name } ));
            }

            lstbxFeedback.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Klaar.");
            lstbxFeedback.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + scan.places.Count + " locaties opgehaald.");
        }

        private void getCoffeeLocations()
        {
            lvCoffeelocations.Items.Clear();

            if (scan.places.Count > 0)
            {
                this.loopPlaces();
            }
            else
            {
                this.getPlaces();
            }
        }

        private async void loopPlaces()
        {
            lstbxFeedback.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Koffielocaties ophalen..");

            foreach (var place in scan.places)
            {
                string url = "http://debestekoffievan.nl/" + place.Name;
                RequestPage request = new RequestPage();
                string response = await request.GetHTML(url);
                scan.fetchCoffeelocations(response);

                foreach (var location in scan.coffeelocations)
                {
                    lvCoffeelocations.Items.Add(new ListViewItem(new String[] { location.Rank.ToString(), location.Name, location.Address, location.City, location.PhoneNr, location.Score } ));

                    string urll = "http://debestekoffievan.nl/" + location.City + "/" + location.Name;
                    RequestPage requestt = new RequestPage();
                    string responsee = await requestt.GetHTML(urll);
                    scan.fetchComments(responsee, location.Name);
                }
            };

            lstbxFeedback.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Klaar.");
            lstbxFeedback.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + lvCoffeelocations.Items.Count + " locaties opgehaald.");
        }
    }
}