namespace Academy
{
    partial class HumanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbId = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbBirthDate = new System.Windows.Forms.Label();
            this.lbMidlName = new System.Windows.Forms.Label();
            this.rtbLastName = new System.Windows.Forms.RichTextBox();
            this.rtbFirstName = new System.Windows.Forms.RichTextBox();
            this.rtbMiddleName = new System.Windows.Forms.RichTextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.buttonPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbId.Location = new System.Drawing.Point(190, 19);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(49, 32);
            this.lbId.TabIndex = 0;
            this.lbId.Text = "ID:";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLastName.Location = new System.Drawing.Point(94, 66);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(145, 32);
            this.lbLastName.TabIndex = 1;
            this.lbLastName.Text = "Фамилия:";
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFirstName.Location = new System.Drawing.Point(162, 113);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(77, 32);
            this.lbFirstName.TabIndex = 2;
            this.lbFirstName.Text = "Имя:";
            // 
            // lbBirthDate
            // 
            this.lbBirthDate.AutoSize = true;
            this.lbBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBirthDate.Location = new System.Drawing.Point(12, 214);
            this.lbBirthDate.Name = "lbBirthDate";
            this.lbBirthDate.Size = new System.Drawing.Size(227, 32);
            this.lbBirthDate.TabIndex = 3;
            this.lbBirthDate.Text = "Дата рождения:";
            // 
            // lbMidlName
            // 
            this.lbMidlName.AutoSize = true;
            this.lbMidlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMidlName.Location = new System.Drawing.Point(93, 163);
            this.lbMidlName.Name = "lbMidlName";
            this.lbMidlName.Size = new System.Drawing.Size(146, 32);
            this.lbMidlName.TabIndex = 4;
            this.lbMidlName.Text = "Отчество:";
            // 
            // rtbLastName
            // 
            this.rtbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbLastName.Location = new System.Drawing.Point(338, 58);
            this.rtbLastName.Multiline = false;
            this.rtbLastName.Name = "rtbLastName";
            this.rtbLastName.Size = new System.Drawing.Size(402, 37);
            this.rtbLastName.TabIndex = 5;
            this.rtbLastName.Text = "";
            // 
            // rtbFirstName
            // 
            this.rtbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbFirstName.Location = new System.Drawing.Point(338, 108);
            this.rtbFirstName.Multiline = false;
            this.rtbFirstName.Name = "rtbFirstName";
            this.rtbFirstName.Size = new System.Drawing.Size(402, 37);
            this.rtbFirstName.TabIndex = 6;
            this.rtbFirstName.Text = "";
            // 
            // rtbMiddleName
            // 
            this.rtbMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbMiddleName.Location = new System.Drawing.Point(338, 158);
            this.rtbMiddleName.Multiline = false;
            this.rtbMiddleName.Name = "rtbMiddleName";
            this.rtbMiddleName.Size = new System.Drawing.Size(402, 37);
            this.rtbMiddleName.TabIndex = 7;
            this.rtbMiddleName.Text = "";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(338, 208);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(402, 38);
            this.dtpBirthDate.TabIndex = 8;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(766, 12);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(352, 285);
            this.pictureBoxPhoto.TabIndex = 9;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // buttonPhoto
            // 
            this.buttonPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPhoto.Location = new System.Drawing.Point(766, 303);
            this.buttonPhoto.Name = "buttonPhoto";
            this.buttonPhoto.Size = new System.Drawing.Size(352, 44);
            this.buttonPhoto.TabIndex = 10;
            this.buttonPhoto.Text = "Обзор";
            this.buttonPhoto.UseVisualStyleBackColor = true;
            // 
            // HumanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 450);
            this.Controls.Add(this.buttonPhoto);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.rtbMiddleName);
            this.Controls.Add(this.rtbFirstName);
            this.Controls.Add(this.rtbLastName);
            this.Controls.Add(this.lbMidlName);
            this.Controls.Add(this.lbBirthDate);
            this.Controls.Add(this.lbFirstName);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "HumanForm";
            this.Text = "Human";
            this.Load += new System.EventHandler(this.Human_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.DateTimePicker dtpBirthDate;
        protected System.Windows.Forms.RichTextBox rtbMiddleName;
        protected System.Windows.Forms.PictureBox pictureBoxPhoto;
        protected System.Windows.Forms.Button buttonPhoto;
        protected System.Windows.Forms.Label lbId;
        protected System.Windows.Forms.Label lbLastName;
        protected System.Windows.Forms.Label lbFirstName;
        protected System.Windows.Forms.Label lbMidlName;
        protected System.Windows.Forms.RichTextBox rtbLastName;
        protected System.Windows.Forms.RichTextBox rtbFirstName;
        protected System.Windows.Forms.Label lbBirthDate;
    }
}