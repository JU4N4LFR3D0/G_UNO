﻿
namespace G_UNO
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadimg_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadgcode_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.update_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salir_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puertoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelar_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.arribaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izquierdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.derechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.laserONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laserOFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.establecerPosicionACerosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.irAlOrigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.update_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadgcode_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadimg_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.port_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancel_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.left_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.right_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.up_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.down_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.laseroff_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.laseron_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.setzeros_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.home_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.versionlbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.gunotoolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.portlbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.consolatbox = new System.Windows.Forms.RichTextBox();
            this.gunoserialPort = new System.IO.Ports.SerialPort(this.components);
            this.gunotimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadimg_toolStripMenuItem,
            this.loadgcode_toolStripMenuItem,
            this.toolStripSeparator10,
            this.update_toolStripMenuItem,
            this.toolStripSeparator1,
            this.salir_toolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // loadimg_toolStripMenuItem
            // 
            this.loadimg_toolStripMenuItem.Image = global::G_UNO.Properties.Resources.image_solid;
            this.loadimg_toolStripMenuItem.Name = "loadimg_toolStripMenuItem";
            this.loadimg_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.loadimg_toolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.loadimg_toolStripMenuItem.Text = "Cargar Imagen";
            this.loadimg_toolStripMenuItem.Click += new System.EventHandler(this.loadimg_toolStripMenuItem_Click);
            // 
            // loadgcode_toolStripMenuItem
            // 
            this.loadgcode_toolStripMenuItem.Image = global::G_UNO.Properties.Resources.file_import_solid;
            this.loadgcode_toolStripMenuItem.Name = "loadgcode_toolStripMenuItem";
            this.loadgcode_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.loadgcode_toolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.loadgcode_toolStripMenuItem.Text = "Cargar Código G";
            this.loadgcode_toolStripMenuItem.Click += new System.EventHandler(this.loadgcode_toolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(201, 6);
            // 
            // update_toolStripMenuItem
            // 
            this.update_toolStripMenuItem.Image = global::G_UNO.Properties.Resources.sync_solid;
            this.update_toolStripMenuItem.Name = "update_toolStripMenuItem";
            this.update_toolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.update_toolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.update_toolStripMenuItem.Text = "Actualizar";
            this.update_toolStripMenuItem.Click += new System.EventHandler(this.update_toolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // salir_toolStripMenuItem
            // 
            this.salir_toolStripMenuItem.Image = global::G_UNO.Properties.Resources.sign_out_alt_solid;
            this.salir_toolStripMenuItem.Name = "salir_toolStripMenuItem";
            this.salir_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salir_toolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.salir_toolStripMenuItem.Text = "Salir";
            this.salir_toolStripMenuItem.Click += new System.EventHandler(this.salir_toolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puertoToolStripMenuItem,
            this.cancelar_toolStripMenuItem,
            this.toolStripSeparator7,
            this.arribaToolStripMenuItem,
            this.abajoToolStripMenuItem,
            this.izquierdaToolStripMenuItem,
            this.derechaToolStripMenuItem,
            this.toolStripSeparator8,
            this.laserONToolStripMenuItem,
            this.laserOFFToolStripMenuItem,
            this.toolStripSeparator9,
            this.establecerPosicionACerosToolStripMenuItem,
            this.irAlOrigenToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // puertoToolStripMenuItem
            // 
            this.puertoToolStripMenuItem.Image = global::G_UNO.Properties.Resources.usb_brands;
            this.puertoToolStripMenuItem.Name = "puertoToolStripMenuItem";
            this.puertoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.puertoToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.puertoToolStripMenuItem.Text = "Puerto";
            this.puertoToolStripMenuItem.Click += new System.EventHandler(this.puertoToolStripMenuItem_Click);
            // 
            // cancelar_toolStripMenuItem
            // 
            this.cancelar_toolStripMenuItem.Image = global::G_UNO.Properties.Resources.ban_solid;
            this.cancelar_toolStripMenuItem.Name = "cancelar_toolStripMenuItem";
            this.cancelar_toolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cancelar_toolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.cancelar_toolStripMenuItem.Text = "Cancelar operación";
            this.cancelar_toolStripMenuItem.Click += new System.EventHandler(this.cancelar_toolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(252, 6);
            // 
            // arribaToolStripMenuItem
            // 
            this.arribaToolStripMenuItem.Image = global::G_UNO.Properties.Resources.arrow_up_solid;
            this.arribaToolStripMenuItem.Name = "arribaToolStripMenuItem";
            this.arribaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.arribaToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.arribaToolStripMenuItem.Text = "Arriba";
            this.arribaToolStripMenuItem.Click += new System.EventHandler(this.arribaToolStripMenuItem_Click);
            // 
            // abajoToolStripMenuItem
            // 
            this.abajoToolStripMenuItem.Image = global::G_UNO.Properties.Resources.arrow_down_solid;
            this.abajoToolStripMenuItem.Name = "abajoToolStripMenuItem";
            this.abajoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.abajoToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.abajoToolStripMenuItem.Text = "Abajo";
            this.abajoToolStripMenuItem.Click += new System.EventHandler(this.abajoToolStripMenuItem_Click);
            // 
            // izquierdaToolStripMenuItem
            // 
            this.izquierdaToolStripMenuItem.Image = global::G_UNO.Properties.Resources.arrow_left_solid;
            this.izquierdaToolStripMenuItem.Name = "izquierdaToolStripMenuItem";
            this.izquierdaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.izquierdaToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.izquierdaToolStripMenuItem.Text = "Izquierda";
            this.izquierdaToolStripMenuItem.Click += new System.EventHandler(this.izquierdaToolStripMenuItem_Click);
            // 
            // derechaToolStripMenuItem
            // 
            this.derechaToolStripMenuItem.Image = global::G_UNO.Properties.Resources.arrow_right_solid;
            this.derechaToolStripMenuItem.Name = "derechaToolStripMenuItem";
            this.derechaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.derechaToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.derechaToolStripMenuItem.Text = "Derecha";
            this.derechaToolStripMenuItem.Click += new System.EventHandler(this.derechaToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(252, 6);
            // 
            // laserONToolStripMenuItem
            // 
            this.laserONToolStripMenuItem.Image = global::G_UNO.Properties.Resources.toggle_on_solid;
            this.laserONToolStripMenuItem.Name = "laserONToolStripMenuItem";
            this.laserONToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.laserONToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.laserONToolStripMenuItem.Text = "Laser ON";
            this.laserONToolStripMenuItem.Click += new System.EventHandler(this.laserONToolStripMenuItem_Click);
            // 
            // laserOFFToolStripMenuItem
            // 
            this.laserOFFToolStripMenuItem.Image = global::G_UNO.Properties.Resources.toggle_off_solid;
            this.laserOFFToolStripMenuItem.Name = "laserOFFToolStripMenuItem";
            this.laserOFFToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.laserOFFToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.laserOFFToolStripMenuItem.Text = "Laser OFF";
            this.laserOFFToolStripMenuItem.Click += new System.EventHandler(this.laserOFFToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(252, 6);
            // 
            // establecerPosicionACerosToolStripMenuItem
            // 
            this.establecerPosicionACerosToolStripMenuItem.Image = global::G_UNO.Properties.Resources.crosshairs_solid;
            this.establecerPosicionACerosToolStripMenuItem.Name = "establecerPosicionACerosToolStripMenuItem";
            this.establecerPosicionACerosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.establecerPosicionACerosToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.establecerPosicionACerosToolStripMenuItem.Text = "Establecer posicion a ceros";
            this.establecerPosicionACerosToolStripMenuItem.Click += new System.EventHandler(this.establecerPosicionACerosToolStripMenuItem_Click);
            // 
            // irAlOrigenToolStripMenuItem
            // 
            this.irAlOrigenToolStripMenuItem.Image = global::G_UNO.Properties.Resources.home_solid;
            this.irAlOrigenToolStripMenuItem.Name = "irAlOrigenToolStripMenuItem";
            this.irAlOrigenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.irAlOrigenToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.irAlOrigenToolStripMenuItem.Text = "Ir al origen";
            this.irAlOrigenToolStripMenuItem.Click += new System.EventHandler(this.irAlOrigenToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.update_toolStripButton,
            this.loadgcode_toolStripButton,
            this.loadimg_toolStripButton,
            this.toolStripSeparator2,
            this.port_toolStripButton,
            this.cancel_toolStripButton,
            this.toolStripSeparator3,
            this.left_toolStripButton,
            this.right_toolStripButton,
            this.up_toolStripButton,
            this.down_toolStripButton,
            this.toolStripSeparator4,
            this.laseroff_toolStripButton,
            this.laseron_toolStripButton,
            this.toolStripSeparator5,
            this.setzeros_toolStripButton,
            this.home_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(894, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // update_toolStripButton
            // 
            this.update_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.update_toolStripButton.Image = global::G_UNO.Properties.Resources.sync_solid;
            this.update_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.update_toolStripButton.Name = "update_toolStripButton";
            this.update_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.update_toolStripButton.Click += new System.EventHandler(this.update_toolStripButton_Click);
            // 
            // loadgcode_toolStripButton
            // 
            this.loadgcode_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadgcode_toolStripButton.Image = global::G_UNO.Properties.Resources.file_import_solid;
            this.loadgcode_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadgcode_toolStripButton.Name = "loadgcode_toolStripButton";
            this.loadgcode_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.loadgcode_toolStripButton.Click += new System.EventHandler(this.loadgcode_toolStripButton_Click);
            // 
            // loadimg_toolStripButton
            // 
            this.loadimg_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadimg_toolStripButton.Image = global::G_UNO.Properties.Resources.image_solid;
            this.loadimg_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadimg_toolStripButton.Name = "loadimg_toolStripButton";
            this.loadimg_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.loadimg_toolStripButton.ToolTipText = "Cargar imagen";
            this.loadimg_toolStripButton.Click += new System.EventHandler(this.loadimg_toolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // port_toolStripButton
            // 
            this.port_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.port_toolStripButton.Image = global::G_UNO.Properties.Resources.usb_brands;
            this.port_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.port_toolStripButton.Name = "port_toolStripButton";
            this.port_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.port_toolStripButton.ToolTipText = "Seleccionar puerto";
            this.port_toolStripButton.Click += new System.EventHandler(this.port_toolStripButton_Click);
            // 
            // cancel_toolStripButton
            // 
            this.cancel_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancel_toolStripButton.Image = global::G_UNO.Properties.Resources.ban_solid;
            this.cancel_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel_toolStripButton.Name = "cancel_toolStripButton";
            this.cancel_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cancel_toolStripButton.ToolTipText = "Cancelar operacion";
            this.cancel_toolStripButton.Click += new System.EventHandler(this.cancel_toolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // left_toolStripButton
            // 
            this.left_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.left_toolStripButton.Image = global::G_UNO.Properties.Resources.arrow_left_solid;
            this.left_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.left_toolStripButton.Name = "left_toolStripButton";
            this.left_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.left_toolStripButton.ToolTipText = "Mover a la izquierda";
            this.left_toolStripButton.Click += new System.EventHandler(this.left_toolStripButton_Click);
            // 
            // right_toolStripButton
            // 
            this.right_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.right_toolStripButton.Image = global::G_UNO.Properties.Resources.arrow_right_solid;
            this.right_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.right_toolStripButton.Name = "right_toolStripButton";
            this.right_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.right_toolStripButton.ToolTipText = "Mover a la derecha";
            this.right_toolStripButton.Click += new System.EventHandler(this.right_toolStripButton_Click);
            // 
            // up_toolStripButton
            // 
            this.up_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.up_toolStripButton.Image = global::G_UNO.Properties.Resources.arrow_up_solid;
            this.up_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.up_toolStripButton.Name = "up_toolStripButton";
            this.up_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.up_toolStripButton.ToolTipText = "Mover hacia arriba";
            this.up_toolStripButton.Click += new System.EventHandler(this.up_toolStripButton_Click);
            // 
            // down_toolStripButton
            // 
            this.down_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.down_toolStripButton.Image = global::G_UNO.Properties.Resources.arrow_down_solid;
            this.down_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.down_toolStripButton.Name = "down_toolStripButton";
            this.down_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.down_toolStripButton.ToolTipText = "Mover hacia abajo";
            this.down_toolStripButton.Click += new System.EventHandler(this.down_toolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // laseroff_toolStripButton
            // 
            this.laseroff_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.laseroff_toolStripButton.Image = global::G_UNO.Properties.Resources.toggle_off_solid;
            this.laseroff_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.laseroff_toolStripButton.Name = "laseroff_toolStripButton";
            this.laseroff_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.laseroff_toolStripButton.ToolTipText = "Apagar laser";
            this.laseroff_toolStripButton.Click += new System.EventHandler(this.laseroff_toolStripButton_Click);
            // 
            // laseron_toolStripButton
            // 
            this.laseron_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.laseron_toolStripButton.Image = global::G_UNO.Properties.Resources.toggle_on_solid;
            this.laseron_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.laseron_toolStripButton.Name = "laseron_toolStripButton";
            this.laseron_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.laseron_toolStripButton.ToolTipText = "Encender laser";
            this.laseron_toolStripButton.Click += new System.EventHandler(this.laseron_toolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // setzeros_toolStripButton
            // 
            this.setzeros_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setzeros_toolStripButton.Image = global::G_UNO.Properties.Resources.crosshairs_solid;
            this.setzeros_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setzeros_toolStripButton.Name = "setzeros_toolStripButton";
            this.setzeros_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.setzeros_toolStripButton.ToolTipText = "Establecer origen";
            this.setzeros_toolStripButton.Click += new System.EventHandler(this.setzeros_toolStripButton_Click);
            // 
            // home_toolStripButton
            // 
            this.home_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.home_toolStripButton.Image = global::G_UNO.Properties.Resources.home_solid;
            this.home_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.home_toolStripButton.Name = "home_toolStripButton";
            this.home_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.home_toolStripButton.ToolTipText = "Ir al origen";
            this.home_toolStripButton.Click += new System.EventHandler(this.home_toolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionlbl,
            this.gunotoolStripProgressBar,
            this.portlbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 645);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(894, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // versionlbl
            // 
            this.versionlbl.Name = "versionlbl";
            this.versionlbl.Size = new System.Drawing.Size(29, 17);
            this.versionlbl.Text = "V1.0";
            // 
            // gunotoolStripProgressBar
            // 
            this.gunotoolStripProgressBar.Name = "gunotoolStripProgressBar";
            this.gunotoolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // portlbl
            // 
            this.portlbl.Name = "portlbl";
            this.portlbl.Size = new System.Drawing.Size(59, 17);
            this.portlbl.Text = "Puerto [  ]";
            // 
            // consolatbox
            // 
            this.consolatbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consolatbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consolatbox.Location = new System.Drawing.Point(0, 52);
            this.consolatbox.Name = "consolatbox";
            this.consolatbox.ReadOnly = true;
            this.consolatbox.Size = new System.Drawing.Size(894, 590);
            this.consolatbox.TabIndex = 3;
            this.consolatbox.Text = "G_UNO\n";
            // 
            // gunoserialPort
            // 
            this.gunoserialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.gunoserialPort_DataReceived);
            // 
            // gunotimer
            // 
            this.gunotimer.Interval = 5000;
            this.gunotimer.Tick += new System.EventHandler(this.gunotimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 667);
            this.Controls.Add(this.consolatbox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "G_UNO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem update_toolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salir_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton update_toolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel versionlbl;
        private System.Windows.Forms.ToolStripMenuItem puertoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem arribaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abajoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izquierdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem derechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem laserONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laserOFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem establecerPosicionACerosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem irAlOrigenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton left_toolStripButton;
        private System.Windows.Forms.ToolStripButton right_toolStripButton;
        private System.Windows.Forms.ToolStripButton up_toolStripButton;
        private System.Windows.Forms.ToolStripButton down_toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton laseroff_toolStripButton;
        private System.Windows.Forms.ToolStripButton laseron_toolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton setzeros_toolStripButton;
        private System.Windows.Forms.ToolStripButton home_toolStripButton;
        private System.Windows.Forms.ToolStripButton cancel_toolStripButton;
        private System.Windows.Forms.ToolStripProgressBar gunotoolStripProgressBar;
        private System.Windows.Forms.RichTextBox consolatbox;
        private System.IO.Ports.SerialPort gunoserialPort;
        private System.Windows.Forms.ToolStripMenuItem loadimg_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadgcode_toolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem cancelar_toolStripMenuItem;
        private System.Windows.Forms.ToolStripButton port_toolStripButton;
        private System.Windows.Forms.ToolStripButton loadgcode_toolStripButton;
        private System.Windows.Forms.ToolStripButton loadimg_toolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel portlbl;
        private System.Windows.Forms.Timer gunotimer;
    }
}
