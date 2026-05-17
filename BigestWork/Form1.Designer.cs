namespace BigestWork
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            labelVisualize = new Label();
            textBoxForPush = new TextBox();
            pushButton = new Button();
            popButton = new Button();
            labelPush = new Label();
            labelPop = new Label();
            textBoxForPop = new TextBox();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItemSave = new ToolStripMenuItem();
            открытьToolStripMenuItemLoad = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            infoButton = new Button();
            traversal = new Button();
            radioButtonForward = new RadioButton();
            radioButtonBackward = new RadioButton();
            buttonFind = new Button();
            textBoxFind = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 67);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(314, 486);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // labelVisualize
            // 
            labelVisualize.AutoSize = true;
            labelVisualize.Location = new Point(12, 39);
            labelVisualize.Name = "labelVisualize";
            labelVisualize.Size = new Size(107, 20);
            labelVisualize.TabIndex = 2;
            labelVisualize.Text = "Визуализация";
            // 
            // textBoxForPush
            // 
            textBoxForPush.Location = new Point(341, 90);
            textBoxForPush.Name = "textBoxForPush";
            textBoxForPush.Size = new Size(144, 27);
            textBoxForPush.TabIndex = 4;
            // 
            // pushButton
            // 
            pushButton.Location = new Point(341, 123);
            pushButton.Name = "pushButton";
            pushButton.Size = new Size(144, 29);
            pushButton.TabIndex = 5;
            pushButton.Text = "Пуш";
            pushButton.UseVisualStyleBackColor = true;
            pushButton.Click += pushButton_Click;
            // 
            // popButton
            // 
            popButton.Location = new Point(341, 238);
            popButton.Name = "popButton";
            popButton.Size = new Size(144, 29);
            popButton.TabIndex = 6;
            popButton.Text = "Поп";
            popButton.UseVisualStyleBackColor = true;
            popButton.Click += popButton_Click;
            // 
            // labelPush
            // 
            labelPush.AutoSize = true;
            labelPush.Location = new Point(341, 67);
            labelPush.Name = "labelPush";
            labelPush.Size = new Size(144, 20);
            labelPush.TabIndex = 7;
            labelPush.Text = "Значение для пуша";
            // 
            // labelPop
            // 
            labelPop.AutoSize = true;
            labelPop.Location = new Point(341, 182);
            labelPop.Name = "labelPop";
            labelPop.Size = new Size(181, 20);
            labelPop.TabIndex = 9;
            labelPop.Text = "Выброшенное значение";
            // 
            // textBoxForPop
            // 
            textBoxForPop.Location = new Point(341, 205);
            textBoxForPop.Name = "textBoxForPop";
            textBoxForPop.ReadOnly = true;
            textBoxForPop.Size = new Size(144, 27);
            textBoxForPop.TabIndex = 8;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(538, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemSave, открытьToolStripMenuItemLoad });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(59, 24);
            toolStripMenuItem1.Text = "Файл";
            // 
            // toolStripMenuItemSave
            // 
            toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            toolStripMenuItemSave.Size = new Size(166, 26);
            toolStripMenuItemSave.Text = "Сохранить";
            toolStripMenuItemSave.Click += toolStripMenuItemSave_Click;
            // 
            // открытьToolStripMenuItemLoad
            // 
            открытьToolStripMenuItemLoad.Name = "открытьToolStripMenuItemLoad";
            открытьToolStripMenuItemLoad.Size = new Size(166, 26);
            открытьToolStripMenuItemLoad.Text = "Открыть";
            открытьToolStripMenuItemLoad.Click += toolStripMenuItemLoad_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // infoButton
            // 
            infoButton.Location = new Point(341, 524);
            infoButton.Name = "infoButton";
            infoButton.Size = new Size(144, 29);
            infoButton.TabIndex = 11;
            infoButton.Text = "Описание";
            infoButton.UseVisualStyleBackColor = true;
            infoButton.Click += infoButton_Click;
            // 
            // traversal
            // 
            traversal.Location = new Point(341, 305);
            traversal.Name = "traversal";
            traversal.Size = new Size(144, 29);
            traversal.TabIndex = 12;
            traversal.Text = "Пройтись";
            traversal.UseVisualStyleBackColor = true;
            traversal.Click += traversal_Click;
            // 
            // radioButtonForward
            // 
            radioButtonForward.AutoSize = true;
            radioButtonForward.Location = new Point(341, 408);
            radioButtonForward.Name = "radioButtonForward";
            radioButtonForward.Size = new Size(84, 24);
            radioButtonForward.TabIndex = 13;
            radioButtonForward.TabStop = true;
            radioButtonForward.Text = "Forward\r\n";
            radioButtonForward.UseVisualStyleBackColor = true;
            // 
            // radioButtonBackward
            // 
            radioButtonBackward.AutoSize = true;
            radioButtonBackward.Location = new Point(341, 438);
            radioButtonBackward.Name = "radioButtonBackward";
            radioButtonBackward.Size = new Size(96, 24);
            radioButtonBackward.TabIndex = 14;
            radioButtonBackward.TabStop = true;
            radioButtonBackward.Text = "BackWard";
            radioButtonBackward.UseVisualStyleBackColor = true;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(341, 340);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(144, 29);
            buttonFind.TabIndex = 15;
            buttonFind.Text = "Найти";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // textBoxFind
            // 
            textBoxFind.Location = new Point(341, 375);
            textBoxFind.Name = "textBoxFind";
            textBoxFind.Size = new Size(144, 27);
            textBoxFind.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 560);
            Controls.Add(textBoxFind);
            Controls.Add(buttonFind);
            Controls.Add(radioButtonBackward);
            Controls.Add(radioButtonForward);
            Controls.Add(traversal);
            Controls.Add(infoButton);
            Controls.Add(labelPop);
            Controls.Add(textBoxForPop);
            Controls.Add(labelPush);
            Controls.Add(popButton);
            Controls.Add(pushButton);
            Controls.Add(textBoxForPush);
            Controls.Add(labelVisualize);
            Controls.Add(pictureBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Визуализация Стека На Двусвязном Списке";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label labelVisualize;
        private TextBox textBoxForPush;
        private Button pushButton;
        private Button popButton;
        private Label labelPush;
        private Label labelPop;
        private TextBox textBoxForPop;
        private MenuStrip menuStrip1;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItemSave;
        private ToolStripMenuItem открытьToolStripMenuItemLoad;
        private Button infoButton;
        private Button traversal;
        private RadioButton radioButtonForward;
        private RadioButton radioButtonBackward;
        private Button buttonFind;
        private TextBox textBoxFind;
    }
}
