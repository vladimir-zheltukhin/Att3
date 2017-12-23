namespace Waggle
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewGameButton = new System.Windows.Forms.Button();
            this.GameField = new System.Windows.Forms.DataGridView();
            this.gameStateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // NewGameButton
            // 
            this.NewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGameButton.Location = new System.Drawing.Point(76, 23);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(111, 37);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // GameField
            // 
            this.GameField.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GameField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GameField.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GameField.Location = new System.Drawing.Point(37, 108);
            this.GameField.Name = "GameField";
            this.GameField.ReadOnly = true;
            this.GameField.Size = new System.Drawing.Size(121, 99);
            this.GameField.TabIndex = 1;
            this.GameField.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GameField_CellMouseClick);
            this.GameField.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gameFieldDataGridView_CellPainting);
            // 
            // gameStateLabel
            // 
            this.gameStateLabel.AutoSize = true;
            this.gameStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameStateLabel.Location = new System.Drawing.Point(34, 73);
            this.gameStateLabel.Name = "gameStateLabel";
            this.gameStateLabel.Size = new System.Drawing.Size(124, 16);
            this.gameStateLabel.TabIndex = 2;
            this.gameStateLabel.Text = "Игра не началась";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 308);
            this.Controls.Add(this.gameStateLabel);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.NewGameButton);
            this.Name = "MainForm";
            this.Text = "Waggle";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.DataGridView GameField;
        private System.Windows.Forms.Label gameStateLabel;
    }
}

