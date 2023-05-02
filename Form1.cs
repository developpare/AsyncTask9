namespace AsyncTask9
{
    public partial class Form1 : Form
    {
        private const int Progress_Maximum_Value = 5;
        public Form1()
        {
            InitializeComponent();
        }
        private void InitOperations()
        {
            labelMessage.Text = "[]";
            logArea.Clear();
            progressBarOperazionePesante.Value = 0;
            progressBarOperazionePesante.Maximum = Progress_Maximum_Value;
        }
        private void SafeLogging(string message, Color selectedColor)
        {
            if (logArea.InvokeRequired)
            {
                logArea.BeginInvoke(() =>
                {
                    logArea.Select(logArea.TextLength, 0);
                    logArea.SelectionColor = selectedColor;
                    logArea.AppendText($"{message} {Environment.NewLine}");
                });
                return;
            }

            logArea.Invoke(() =>
            {
                logArea.Select(logArea.TextLength, 0);
                logArea.SelectionColor = selectedColor;
                logArea.AppendText($"{message} {Environment.NewLine}");
                logArea.Update();
            });
        }
        private void UpdateLabelMessage(string message)
        {
            SafeLogging($"Update LabelMessage dal Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Yellow);

            try
            {
                labelMessage.Text = message;
                labelMessage.Update();
            }
            catch (InvalidOperationException ex)
            {
                SafeLogging("--------------------------------------", Color.Magenta);

                SafeLogging($"UpdateLabelMessage => InvalidOperationException sul Thread ID = " +
                    $"{Thread.CurrentThread.ManagedThreadId}", Color.Red);

                SafeLogging($"Error Message: {ex.Message}", Color.Red);

                SafeLogging("--------------------------------------", Color.Magenta);
            }
        }
        private void OperazionePesanteBase()
        {
            try
            {
                SafeLogging($"OperazionePesante Start sul Thread con Thread ID  = " +
                    $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);

                for (int i = 1; i <= Progress_Maximum_Value; i++)
                {
                    var currentThreadId = Thread.CurrentThread.ManagedThreadId;

                    Thread.Sleep(500);

                    SafeLogging($"Esecuzione di OperazionePesante sul Thread con Thread ID  = " +
                        $"{currentThreadId}", Color.RebeccaPurple);

                    progressBarOperazionePesante.Value = i;

                }

                SafeLogging($"OperazionePesante End sul Thread con Thread ID  = {Thread.CurrentThread.ManagedThreadId}", Color.Green);
            }
            catch (InvalidOperationException ex)
            {
                SafeLogging("--------------------------------------", Color.Magenta);

                SafeLogging($"OperazionePesante => InvalidOperationException sul Thread ID = " +
                    $"{Thread.CurrentThread.ManagedThreadId}", Color.Red);

                SafeLogging($"Error Message: {ex.Message}", Color.Red);

                SafeLogging("--------------------------------------", Color.Magenta);
            }
        }


        private void buttonSynchExecution_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            OperazionePesanteBase();

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }
        private void OperazionePesanteThreadSynchronizationContextTest(object? inputSynchronizationContext)
        {
            try
            {
                SynchronizationContext? synchronizationContext = inputSynchronizationContext as SynchronizationContext;

                SafeLogging($"OperazionePesante Start sul Thread ID  = " +
                    $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);

                for (int i = 1; i <= Progress_Maximum_Value; i++)
                {
                    var currentThreadId = Thread.CurrentThread.ManagedThreadId;

                    Thread.Sleep(500);
                    var index = i;

                    SafeLogging($"Esecuzione di OperazionePesante sul Thread con Thread ID  = " +
                        $"{currentThreadId}", Color.RebeccaPurple);

                    synchronizationContext!.Post(_ => progressBarOperazionePesante.Value = index, null);
                }

                Thread.Sleep(100);

                SafeLogging($"OperazionePesante End sul Thread ID  = " +
                    $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);
            }
            catch (InvalidOperationException ex)
            {
                SafeLogging("--------------------------------------", Color.Magenta);
                SafeLogging($"OperazionePesante => InvalidOperationException sul Thread ID = " +
                    $"{Thread.CurrentThread.ManagedThreadId}", Color.Red);
                SafeLogging($"Error Message: {ex.Message}", Color.Red);
                SafeLogging("--------------------------------------", Color.Magenta);
            }
        }


        private void buttonThreadNoSyncContext_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            Thread threadOperazionePesante = new Thread(OperazionePesanteBase);

            threadOperazionePesante.Start();

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }

        private void buttonThreadWithSyncContext_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            Thread threadOperazionePesante = new Thread(OperazionePesanteThreadSynchronizationContextTest);

            threadOperazionePesante.Start(SynchronizationContext.Current);

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }
        private Task OperazionePesanteTaskNoSynchronizationContextTest()
        {
            return Task.Run(() =>
            {
                try
                {
                    SafeLogging($"OperazionePesante Start sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);

                    for (int i = 1; i <= Progress_Maximum_Value; i++)
                    {
                        Thread.Sleep(500);

                        var currentThreadId = Thread.CurrentThread.ManagedThreadId;

                        var index = i;

                        SafeLogging($"Esecuzione di OperazionePesante sul Thread con Thread ID  = " +
                            $"{currentThreadId}", Color.RebeccaPurple);

                        progressBarOperazionePesante.Value = index;
                    }

                    SafeLogging($"OperazionePesante End sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);
                }
                catch (InvalidOperationException ex)
                {
                    SafeLogging("--------------------------------------", Color.Magenta);
                    SafeLogging($"OperazionePesante => InvalidOperationException sul Thread ID = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Red);
                    SafeLogging($"Error Message: {ex.Message}", Color.Red);
                    SafeLogging("--------------------------------------", Color.Magenta);
                }
            });
        }

        private Task OperazionePesanteTaskSynchronizationContextTest(SynchronizationContext synchronizationContext)
        {
            return Task.Run(() =>
            {
                try
                {
                    SafeLogging($"OperazionePesante Start sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);

                    for (int i = 1; i <= Progress_Maximum_Value; i++)
                    {
                        var currentThreadId = Thread.CurrentThread.ManagedThreadId;

                        Thread.Sleep(500);

                        var index = i;

                        SafeLogging($"Esecuzione di OperazionePesante sul Thread con Thread ID  = " +
                            $"{currentThreadId}", Color.RebeccaPurple);

                        synchronizationContext!.Post(_ => progressBarOperazionePesante.Value = index, null);
                    }

                    SafeLogging($"OperazionePesante End sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);
                }
                catch (InvalidOperationException ex)
                {
                    SafeLogging("--------------------------------------", Color.Magenta);
                    SafeLogging($"OperazionePesante => InvalidOperationException sul Thread ID = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Red);
                    SafeLogging($"Error Message: {ex.Message}", Color.Red);
                    SafeLogging("--------------------------------------", Color.Magenta);
                }
            });
        }


        private async void buttonTaskNoSynchronization_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            await OperazionePesanteTaskNoSynchronizationContextTest();

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }

        private async void buttonTaskWithSynchronization_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            await OperazionePesanteTaskSynchronizationContextTest(SynchronizationContext.Current);

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }

        private async void SimpleConfigureAwaitFalse_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            await OperazionePesanteTaskSynchronizationContextTest(SynchronizationContext.Current).ConfigureAwait(false);

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }

        private async void SimpleConfigureAwaitTrue_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            await OperazionePesanteTaskSynchronizationContextTest(SynchronizationContext.Current).ConfigureAwait(true);

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }
        private async Task OperazionePesanteConfigureAwaitInnerTrueTest(SynchronizationContext synchronizationContext)
        {
            await Task.Run(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(synchronizationContext);

                try
                {
                    SafeLogging($"OperazionePesante Start sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);

                    for (int i = 1; i <= Progress_Maximum_Value; i++)
                    {
                        await Task.Delay(500);

                        var currentThreadId = Thread.CurrentThread.ManagedThreadId;

                        var index = i;

                        SafeLogging($"Esecuzione di OperazionePesante sul Thread con Thread ID  = " +
                            $"{currentThreadId}", Color.RebeccaPurple);

                        progressBarOperazionePesante.Value = index;
                    }

                    SafeLogging($"OperazionePesante End sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);
                }
                catch (InvalidOperationException ex)
                {
                    SafeLogging("--------------------------------------", Color.Magenta);
                    SafeLogging($"OperazionePesante => InvalidOperationException sul Thread ID = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Red);
                    SafeLogging($"Error Message: {ex.Message}", Color.Red);
                    SafeLogging("--------------------------------------", Color.Magenta);
                }
            });
        }

        private async Task OperazionePesanteConfigureAwaitInnerTrueErrorTest(SynchronizationContext synchronizationContext)
        {
            await Task.Run(async () =>
            {
                SynchronizationContext.SetSynchronizationContext(synchronizationContext);

                try
                {
                    SafeLogging($"OperazionePesante Start sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);

                    for (int i = 1; i <= Progress_Maximum_Value; i++)
                    {
                        var currentThreadId = Thread.CurrentThread.ManagedThreadId;

                        var index = i;

                        SafeLogging($"Esecuzione di OperazionePesante sul Thread con Thread ID  = " +
                            $"{currentThreadId}", Color.RebeccaPurple);

                        progressBarOperazionePesante.Value = index;

                        await Task.Delay(500);
                    }

                    SafeLogging($"OperazionePesante End sul Thread ID  = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Green);
                }
                catch (InvalidOperationException ex)
                {
                    SafeLogging("--------------------------------------", Color.Magenta);
                    SafeLogging($"OperazionePesante => InvalidOperationException sul Thread ID = " +
                        $"{Thread.CurrentThread.ManagedThreadId}", Color.Red);
                    SafeLogging($"Error Message: {ex.Message}", Color.Red);
                    SafeLogging("--------------------------------------", Color.Magenta);
                }
            });
        }

        private async void configureAwaitTrue_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            await OperazionePesanteConfigureAwaitInnerTrueTest(SynchronizationContext.Current);

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");

        }

        private async void configureAwaitTrueError_Click(object sender, EventArgs e)
        {
            string buttonName = (sender as Button).Text;

            InitOperations();

            SafeLogging($"UI Thread con Thread ID = {Thread.CurrentThread.ManagedThreadId}", Color.White);

            UpdateLabelMessage($"Click Button: {buttonName}");

            SafeLogging($"Flusso prima di OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            await OperazionePesanteConfigureAwaitInnerTrueErrorTest(SynchronizationContext.Current);

            SafeLogging($"Continuazione del flusso dopo OperazionePesante sul Thread con Thread ID = " +
                $"{Thread.CurrentThread.ManagedThreadId}", Color.Teal);

            UpdateLabelMessage($"Exit Click Button: {buttonName}");
        }
    }
}