﻿using COA_IMS.Screens.Subscreens.ActivityLogs;
using COA_IMS.Utilities;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COA_IMS.Screens.Subscrn;

namespace COA_IMS.Screens.scrn
{
    public partial class InventoryMain : Form
    {
        private Tab_Manager tab_Manager = new Tab_Manager();

        private Form current_Form = null;

        private readonly InventoryTable inventory_Table = new InventoryTable();
        private readonly ArchiveInventoryTable archive_Table = new ArchiveInventoryTable();
        private readonly CategoryTab category_tab = new CategoryTab();
        private readonly IMS_SuplierTable ims_supliertable = new IMS_SuplierTable();

        private List<Control> navButtons = new List<Control>();
        public InventoryMain()
        {
            InitializeComponent();
            foreach (GunaAdvenceButton buttoan in nav_panel.Controls)
                navButtons.Add(buttoan);
        }
        private void button_Click(object sender, EventArgs e)
        {
            var button = (GunaAdvenceButton)sender;
            switch (button.Name)
            {
                case "inventory_Table_Btn":
                    current_Form = tab_Manager.switch_Form(inventory_Table, current_Form, content_Panel);
                    break;

                case "archived_Table_Btn":
                    current_Form = tab_Manager.switch_Form(archive_Table, current_Form, content_Panel);
                    break;

                case "categorybtn":
                    current_Form = tab_Manager.switch_Form(category_tab, current_Form, content_Panel);
                    break;

                case "Supplierbtn":
                    current_Form = tab_Manager.switch_Form(ims_supliertable, current_Form, content_Panel);
                    break;
                case "disposalBtn":
                    break;
            }
            tab_Manager.active_AdvButton(button, false, false);
        }

        private void InventoryMain_Load(object sender, EventArgs e)
        {
            tab_Manager = new Tab_Manager();

            //foreach (Control control in nav_panel.Controls)
            //    if (control is GunaAdvenceButton)
            //        tab_Manager.Nav_buttons.Add(control);
            tab_Manager.TakeAllAdvButtonsFromFlowLay(nav_panel);

            tab_Manager.set_Colors("#1B303B", "#C7C8CC");
            tab_Manager.active_AdvButton(inventory_Table_Btn, false, false);

            inventory_Table_Btn.PerformClick();
        }

    }
}