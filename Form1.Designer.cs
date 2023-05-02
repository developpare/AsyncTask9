namespace AsyncTask9
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
            logArea = new RichTextBox();
            progressBarOperazionePesante = new ProgressBar();
            labelMessage = new Label();
            buttonSynchExecution = new Button();
            buttonThreadNoSyncContext = new Button();
            buttonThreadWithSyncContext = new Button();
            buttonTaskNoSynchronization = new Button();
            buttonTaskWithSynchronization = new Button();
            SimpleConfigureAwaitFalse = new Button();
            SimpleConfigureAwaitTrue = new Button();
            configureAwaitTrue = new Button();
            configureAwaitTrueError = new Button();
            SuspendLayout();
            // 
            // logArea
            // 
            logArea.BackColor = Color.Black;
            logArea.BorderStyle = BorderStyle.FixedSingle;
            logArea.Dock = DockStyle.Bottom;
            logArea.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            logArea.ForeColor = Color.White;
            logArea.Location = new Point(0, 298);
            logArea.Name = "logArea";
            logArea.Size = new Size(1020, 414);
            logArea.TabIndex = 0;
            logArea.Text = "";
            // 
            // progressBarOperazionePesante
            // 
            progressBarOperazionePesante.Location = new Point(22, 241);
            progressBarOperazionePesante.Name = "progressBarOperazionePesante";
            progressBarOperazionePesante.Size = new Size(980, 23);
            progressBarOperazionePesante.TabIndex = 1;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMessage.Location = new Point(22, 268);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(20, 21);
            labelMessage.TabIndex = 2;
            labelMessage.Text = "[]";
            // 
            // buttonSynchExecution
            // 
            buttonSynchExecution.Location = new Point(24, 24);
            buttonSynchExecution.Name = "buttonSynchExecution";
            buttonSynchExecution.Size = new Size(234, 23);
            buttonSynchExecution.TabIndex = 3;
            buttonSynchExecution.Text = "Sync Execution";
            buttonSynchExecution.UseVisualStyleBackColor = true;
            buttonSynchExecution.Click += buttonSynchExecution_Click;
            // 
            // buttonThreadNoSyncContext
            // 
            buttonThreadNoSyncContext.Location = new Point(22, 58);
            buttonThreadNoSyncContext.Name = "buttonThreadNoSyncContext";
            buttonThreadNoSyncContext.Size = new Size(236, 23);
            buttonThreadNoSyncContext.TabIndex = 4;
            buttonThreadNoSyncContext.Text = "Thread No SynchronizationContext";
            buttonThreadNoSyncContext.UseVisualStyleBackColor = true;
            buttonThreadNoSyncContext.Click += buttonThreadNoSyncContext_Click;
            // 
            // buttonThreadWithSyncContext
            // 
            buttonThreadWithSyncContext.Location = new Point(273, 58);
            buttonThreadWithSyncContext.Name = "buttonThreadWithSyncContext";
            buttonThreadWithSyncContext.Size = new Size(231, 23);
            buttonThreadWithSyncContext.TabIndex = 5;
            buttonThreadWithSyncContext.Text = "Thread With SynchronizationContext";
            buttonThreadWithSyncContext.UseVisualStyleBackColor = true;
            buttonThreadWithSyncContext.Click += buttonThreadWithSyncContext_Click;
            // 
            // buttonTaskNoSynchronization
            // 
            buttonTaskNoSynchronization.Location = new Point(24, 96);
            buttonTaskNoSynchronization.Name = "buttonTaskNoSynchronization";
            buttonTaskNoSynchronization.Size = new Size(234, 23);
            buttonTaskNoSynchronization.TabIndex = 6;
            buttonTaskNoSynchronization.Text = "Task No SynchronizationContext";
            buttonTaskNoSynchronization.UseVisualStyleBackColor = true;
            buttonTaskNoSynchronization.Click += buttonTaskNoSynchronization_Click;
            // 
            // buttonTaskWithSynchronization
            // 
            buttonTaskWithSynchronization.Location = new Point(273, 96);
            buttonTaskWithSynchronization.Name = "buttonTaskWithSynchronization";
            buttonTaskWithSynchronization.Size = new Size(232, 23);
            buttonTaskWithSynchronization.TabIndex = 7;
            buttonTaskWithSynchronization.Text = "Task With SynchronizationContext";
            buttonTaskWithSynchronization.UseVisualStyleBackColor = true;
            buttonTaskWithSynchronization.Click += buttonTaskWithSynchronization_Click;
            // 
            // SimpleConfigureAwaitFalse
            // 
            SimpleConfigureAwaitFalse.Location = new Point(22, 131);
            SimpleConfigureAwaitFalse.Name = "SimpleConfigureAwaitFalse";
            SimpleConfigureAwaitFalse.Size = new Size(236, 23);
            SimpleConfigureAwaitFalse.TabIndex = 8;
            SimpleConfigureAwaitFalse.Text = "Simple ConfigureAwait => false";
            SimpleConfigureAwaitFalse.UseVisualStyleBackColor = true;
            SimpleConfigureAwaitFalse.Click += SimpleConfigureAwaitFalse_Click;
            // 
            // SimpleConfigureAwaitTrue
            // 
            SimpleConfigureAwaitTrue.Location = new Point(273, 131);
            SimpleConfigureAwaitTrue.Name = "SimpleConfigureAwaitTrue";
            SimpleConfigureAwaitTrue.Size = new Size(230, 23);
            SimpleConfigureAwaitTrue.TabIndex = 9;
            SimpleConfigureAwaitTrue.Text = "Simple ConfigureAwait => true";
            SimpleConfigureAwaitTrue.UseVisualStyleBackColor = true;
            SimpleConfigureAwaitTrue.Click += SimpleConfigureAwaitTrue_Click;
            // 
            // configureAwaitTrue
            // 
            configureAwaitTrue.Location = new Point(22, 168);
            configureAwaitTrue.Name = "configureAwaitTrue";
            configureAwaitTrue.Size = new Size(493, 23);
            configureAwaitTrue.TabIndex = 10;
            configureAwaitTrue.Text = "ConfigureAwait => True Final Example";
            configureAwaitTrue.UseVisualStyleBackColor = true;
            configureAwaitTrue.Click += configureAwaitTrue_Click;
            // 
            // configureAwaitTrueError
            // 
            configureAwaitTrueError.Location = new Point(22, 202);
            configureAwaitTrueError.Name = "configureAwaitTrueError";
            configureAwaitTrueError.Size = new Size(493, 23);
            configureAwaitTrueError.TabIndex = 11;
            configureAwaitTrueError.Text = "ConfigureAwait => True Final Example Error";
            configureAwaitTrueError.UseVisualStyleBackColor = true;
            configureAwaitTrueError.Click += configureAwaitTrueError_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 712);
            Controls.Add(configureAwaitTrueError);
            Controls.Add(configureAwaitTrue);
            Controls.Add(SimpleConfigureAwaitTrue);
            Controls.Add(SimpleConfigureAwaitFalse);
            Controls.Add(buttonTaskWithSynchronization);
            Controls.Add(buttonTaskNoSynchronization);
            Controls.Add(buttonThreadWithSyncContext);
            Controls.Add(buttonThreadNoSyncContext);
            Controls.Add(buttonSynchExecution);
            Controls.Add(labelMessage);
            Controls.Add(progressBarOperazionePesante);
            Controls.Add(logArea);
            Name = "Form1";
            Text = "AsyncTask 9 Example";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox logArea;
        private ProgressBar progressBarOperazionePesante;
        private Label labelMessage;
        private Button buttonSynchExecution;
        private Button buttonThreadNoSyncContext;
        private Button buttonThreadWithSyncContext;
        private Button buttonTaskNoSynchronization;
        private Button buttonTaskWithSynchronization;
        private Button SimpleConfigureAwaitFalse;
        private Button SimpleConfigureAwaitTrue;
        private Button configureAwaitTrue;
        private Button configureAwaitTrueError;
    }
}