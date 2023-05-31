using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ProjectDraft
{
    public partial class GoogleMap : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markeroverlay;
        double lat;
        double lng;


        public GoogleMap()
        {
            InitializeComponent();
            lat = 31.771959;
            lng = 35.217018;
        }
        public GoogleMap(string str)
        {
            InitializeComponent();

                string str1 = str.Substring(1, str.Length - 2);
                string[] srr = str1.Split(',');
                lat = double.Parse(srr[0]);
                lng = double.Parse(srr[1]);
           
              


        }

        private void GoogleMap_Load(object sender, EventArgs e)
        {
            Map1.DragButton = MouseButtons.Right;
            Map1.MapProvider = GMapProviders.GoogleMap;
            Map1.CanDragMap = true;
            Map1.MinZoom = 0;
            Map1.MaxZoom = 24;
            Map1.Zoom = 8;
            Map1.AutoScroll = true;
            Map1.Position = new PointLatLng(lat, lng);
            markeroverlay = new GMapOverlay();
            marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red);
            //markeroverlay.Markers.Add(marker);
            marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipMode=string.Format("")
            Map1.Overlays.Add(markeroverlay);
            marker.Position = new PointLatLng(lat, lng);
            markeroverlay.Markers.Add(marker);


        }

        private void Map1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
             lat = Map1.FromLocalToLatLng(e.X, e.Y).Lat;
             lng = Map1.FromLocalToLatLng(e.X, e.Y).Lng;
           
           //marker = null;
            //marker.Position = new PointLatLng();
            marker.Position = new PointLatLng(lat, lng);
            markeroverlay.Markers.Add(marker);
            // marker = null;
        }

        private void Map1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        public double lng1()
        {
            return lng;
        }
        public double lat1()
        {
            return lat;
        }

        public string SaveLoc()
        {
            string str = "("+lat+","+lng+")"; 
            return str;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(" + lat + "," + lng + ")");
            Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(" + lat + "," + lng + ")");
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
