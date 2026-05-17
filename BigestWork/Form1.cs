using BigestWork.Draw;
using BigestWork.Loggers;
using BigestWork.Logic;

namespace BigestWork;

public partial class Form1 : System.Windows.Forms.Form
{
    private DrawUtility _drawUtility;
    private ActionWithStack? _action;

    private readonly System.Windows.Forms.Timer _animTimer;

    private System.Windows.Forms.Timer _traversalTimer = new();
    private List<int> _traversalItems = new();
    private int _traversalIndex = 0;

    private System.Windows.Forms.Timer _findTimer = new();
    private List<int> _findItems = new();
    private int _findIndex = 0;
    private string _findValue = string.Empty;
    private bool _findFound = false;

    public Form1()
    {
        InitializeComponent();

        _drawUtility = new DrawUtility(pictureBox.Width, pictureBox.Height);

        _action = new ActionWithStack();
        _action.Configure(new Setting());

        _animTimer = new System.Windows.Forms.Timer();
        _animTimer.Interval = 16;
        _animTimer.Tick += AnimTimer_Tick;

        pictureBox.Image = _drawUtility.Draw();

        Logger.Log("Начало работы", LogType.Info);
    }

    private void AnimTimer_Tick(object? sender, EventArgs e)
    {
        bool stillAnimating = _drawUtility.Tick();
        pictureBox.Image = _drawUtility.Draw();

        if (!stillAnimating)
            _animTimer.Stop();
    }

    private void pushButton_Click(object sender, EventArgs e)
    {
        if (!_drawUtility.Tick())
        {
            if (_action is null)
            {
                MessageBox.Show("Ошибка: отсутствие алгоритма");
                Logger.Log("Попытка работы с не созданным стеком", LogType.Error);
                return;
            }

            string value = textBoxForPush.Text.Trim();

            if (value.Length == 0)
            {
                MessageBox.Show("Нельзя запушить пустое значение");
                Logger.Log("Попытка запушить пустоту", LogType.Error);
                return;
            }

            _action.Push(value);
            _drawUtility.AnimatePush(value);

            textBoxForPush.Clear();
            _animTimer.Start();
        }
    }

    private void popButton_Click(object sender, EventArgs e)
    {
        if (!_drawUtility.Tick())
        {
            if (_action is null)
            {
                MessageBox.Show("Ошибка: отсутствие алгоритма");
                Logger.Log("Попытка работы с не созданным стеком", LogType.Error);
                return;
            }

            string? popped = _action.Pop();

            if (popped is not null)
            {
                textBoxForPop.Text = popped;
                _drawUtility.AnimatePop();
                _animTimer.Start();
            }
            else
            {
                textBoxForPop.Text = string.Empty;
                MessageBox.Show("Предупреждение: стек пуст");
                Logger.Log("Попытка сделать поп у пустого стека", LogType.Warning);
            }
        }
    }

    private void toolStripMenuItemSave_Click(object sender, EventArgs e)
    {
        if (_action is null)
        {
            MessageBox.Show("Ошибка: отсутствие алгоритма");
            Logger.Log("Попытка работы с не созданным стеком", LogType.Error);

            return;
        }

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            if (_action.SaveInFile(saveFileDialog.FileName))
            {
                MessageBox.Show("Успешно сохранено");
                Logger.Log("сохранение в файл", LogType.Info);
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении");
                Logger.Log("Ошибка при сохранении", LogType.Warning);
            }

        }
    }
    private void toolStripMenuItemLoad_Click(object sender, EventArgs e)
    {
        if (_action is null)
        {
            MessageBox.Show("Ошибка: отсутствие алгоритма");
            Logger.Log("Попытка работы с не созданным стеком", LogType.Error);

            return;
        }

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            if (_action.LoadFromFile(openFileDialog.FileName))
            {
                SyncDrawUtilityWithStack();
                _animTimer.Start();

                MessageBox.Show("Успешно загружено");
                Logger.Log("загрузка из файла", LogType.Info);
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке");
                Logger.Log("Ошибка при загрузке", LogType.Warning);
            }

        }
    }

    private void SyncDrawUtilityWithStack()
    {
        _drawUtility = new DrawUtility(pictureBox.Width, pictureBox.Height);

        var list = _action!.GetCopyOfInnerList();

        var items = list.ToList();
        for (int i = items.Count - 1; i >= 0; i--)
            _drawUtility.AnimatePush(items[i]);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _animTimer.Stop();
        _animTimer.Dispose();
        _traversalTimer.Stop();
        _traversalTimer.Dispose();
        _findTimer.Stop();
        _findTimer.Dispose();
        base.OnFormClosed(e);
    }

    private void infoButton_Click(object sender, EventArgs e)
    {
        if (_action is null)
        {
            MessageBox.Show("Ошибка: отсутствие алгоритма");
            Logger.Log("Попытка работы с не созданным стеком", LogType.Error);

            return;
        }

        MessageBox.Show(_action.GetDescription());
    }

    private void traversal_Click(object sender, EventArgs e)
    {
        if (_action is null)
        {
            MessageBox.Show("Ошибка: отсутствие алгоритма");
            Logger.Log("Попытка работы с не созданным стеком", LogType.Error);
            return;
        }

        if (_action.IsEmpty())
        {
            MessageBox.Show("Стек пуст");
            return;
        }

        if (!radioButtonForward.Checked && !radioButtonBackward.Checked)
        {
            MessageBox.Show("Не выбран метод прохода");
            return;
        }

        _traversalTimer.Stop();
        _drawUtility.ClearHighlight();

        int count = _drawUtility.ElementCount;
        _traversalItems = Enumerable.Range(0, count).ToList();

        if (radioButtonBackward.Checked)
            _traversalItems.Reverse();

        _traversalIndex = 0;

        _traversalTimer = new System.Windows.Forms.Timer { Interval = 400 };
        _traversalTimer.Tick += TraversalTimer_Tick;
        _traversalTimer.Start();
    }

    private void TraversalTimer_Tick(object? sender, EventArgs e)
    {
        if (_traversalIndex < _traversalItems.Count)
        {
            _drawUtility.SetHighlight(_traversalItems[_traversalIndex]);
            pictureBox.Image = _drawUtility.Draw();
            _traversalIndex++;
        }
        else
        {
            _traversalTimer.Stop();
            _drawUtility.ClearHighlight();
            pictureBox.Image = _drawUtility.Draw();
        }
    }

    private void buttonFind_Click(object sender, EventArgs e)
    {
        if (_action is null)
        {
            MessageBox.Show("Ошибка: отсутствие алгоритма");
            Logger.Log("Попытка работы с не созданным стеком", LogType.Error);
            return;
        }

        if (_action.IsEmpty())
        {
            MessageBox.Show("Стек пуст");
            return;
        }

        string value = textBoxFind.Text.Trim();
        if (value.Length == 0)
        {
            MessageBox.Show("Введите значение для поиска");
            return;
        }

        if (!radioButtonForward.Checked && !radioButtonBackward.Checked)
        {
            MessageBox.Show("Не выбран метод прохода");
            return;
        }

        _findTimer.Stop();
        _drawUtility.ClearHighlight();

        _findValue = value;
        _findFound = false;

        int count = _drawUtility.ElementCount;
        _findItems = Enumerable.Range(0, count).ToList();

        if (radioButtonBackward.Checked)
            _findItems.Reverse();

        _findIndex = 0;

        _findTimer = new System.Windows.Forms.Timer { Interval = 400 };
        _findTimer.Tick += FindTimer_Tick;
        _findTimer.Start();
    }

    private void FindTimer_Tick(object? sender, EventArgs e)
    {
        if (_findIndex < _findItems.Count)
        {
            int visualIndex = _findItems[_findIndex];
            _drawUtility.SetHighlight(visualIndex);
            pictureBox.Image = _drawUtility.Draw();

            var list = _action!.GetCopyOfInnerList().ToList();
            string elementValue = list[visualIndex];

            if (elementValue == _findValue)
            {
                _findFound = true;
                _findTimer.Stop();

                var msgTimer = new System.Windows.Forms.Timer { Interval = 200 };
                msgTimer.Tick += (s, _) =>
                {
                    msgTimer.Stop();
                    msgTimer.Dispose();
                    MessageBox.Show($"Найдено: \"{_findValue}\"");
                    _drawUtility.ClearHighlight();
                    pictureBox.Image = _drawUtility.Draw();
                };
                msgTimer.Start();
                return;
            }

            _findIndex++;
        }
        else
        {
            _findTimer.Stop();
            _drawUtility.ClearHighlight();
            pictureBox.Image = _drawUtility.Draw();

            if (!_findFound)
                MessageBox.Show($"Значение \"{_findValue}\" не найдено");
        }
    }

}
