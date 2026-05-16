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
            addButton = new Button();
            labelVisualize = new Label();
            labelSetting = new Label();
            textBoxForPush = new TextBox();
            pushButton = new Button();
            popButton = new Button();
            labelPush = new Label();
            labelPop = new Label();
            textBoxForPop = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 40);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(314, 486);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 567);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 1;
            addButton.Text = "Создать";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // labelVisualize
            // 
            labelVisualize.AutoSize = true;
            labelVisualize.Location = new Point(12, 12);
            labelVisualize.Name = "labelVisualize";
            labelVisualize.Size = new Size(107, 20);
            labelVisualize.TabIndex = 2;
            labelVisualize.Text = "Визуализация";
            // 
            // labelSetting
            // 
            labelSetting.AutoSize = true;
            labelSetting.Location = new Point(12, 539);
            labelSetting.Name = "labelSetting";
            labelSetting.Size = new Size(83, 20);
            labelSetting.TabIndex = 3;
            labelSetting.Text = "Настройка";
            // 
            // textBoxForPush
            // 
            textBoxForPush.Location = new Point(341, 63);
            textBoxForPush.Name = "textBoxForPush";
            textBoxForPush.Size = new Size(144, 27);
            textBoxForPush.TabIndex = 4;
            // 
            // pushButton
            // 
            pushButton.Location = new Point(341, 96);
            pushButton.Name = "pushButton";
            pushButton.Size = new Size(144, 29);
            pushButton.TabIndex = 5;
            pushButton.Text = "Пуш";
            pushButton.UseVisualStyleBackColor = true;
            pushButton.Click += pushButton_Click;
            // 
            // popButton
            // 
            popButton.Location = new Point(341, 211);
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
            labelPush.Location = new Point(341, 40);
            labelPush.Name = "labelPush";
            labelPush.Size = new Size(144, 20);
            labelPush.TabIndex = 7;
            labelPush.Text = "Значение для пуша";
            // 
            // labelPop
            // 
            labelPop.AutoSize = true;
            labelPop.Location = new Point(341, 155);
            labelPop.Name = "labelPop";
            labelPop.Size = new Size(181, 20);
            labelPop.TabIndex = 9;
            labelPop.Text = "Выброшенное значение";
            // 
            // textBoxForPop
            // 
            textBoxForPop.Location = new Point(341, 178);
            textBoxForPop.Name = "textBoxForPop";
            textBoxForPop.Size = new Size(144, 27);
            textBoxForPop.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 632);
            Controls.Add(labelPop);
            Controls.Add(textBoxForPop);
            Controls.Add(labelPush);
            Controls.Add(popButton);
            Controls.Add(pushButton);
            Controls.Add(textBoxForPush);
            Controls.Add(labelSetting);
            Controls.Add(labelVisualize);
            Controls.Add(addButton);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Визуализация Стека На Двусвязном Списке";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button addButton;
        private Label labelVisualize;
        private Label labelSetting;
        private TextBox textBoxForPush;
        private Button pushButton;
        private Button popButton;
        private Label labelPush;
        private Label labelPop;
        private TextBox textBoxForPop;
    }
}
