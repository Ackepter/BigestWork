using BigestWork.Draw;
using BigestWork.Loggers;
using BigestWork.Logic;

namespace BigestWork;

public partial class Form1 : System.Windows.Forms.Form
{
    private DrawUtility _drawUtility;

    private ActionWithStack? _action;

    public Form1()
    {
        InitializeComponent();

        _drawUtility = new DrawUtility(pictureBox.Width, pictureBox.Height);

        _action = new ActionWithStack();
        _action.Configure(new Setting());

        _drawUtility.SetStack(_action);

        Logger.Log("Начало работы", LogType.Info);
    }

    private void pushButton_Click(object sender, EventArgs e)
    {
        if (_action is not null)
        {
            if (textBoxForPush.Text.CompareTo(string.Empty) != 0)
            {
                _action.Push(textBoxForPush.Text);
                UpdatePictureBox();
            }
            else
            {
                MessageBox.Show("Нельзя запушить ничего");
                Logger.Log("Попытка запушить пустоту", LogType.Error);
            }
        }
        else
        {
            MessageBox.Show("Ошибка: отсутствие алгоритма");
            Logger.Log("Попытка работы с не созданным стеком", LogType.Error);
        }
    }

    private void popButton_Click(object sender, EventArgs e)
    {
        if (_action is not null)
        {
            string? buff = _action.Pop();
            if (buff != null)
            {
                textBoxForPop.Text = buff;
                UpdatePictureBox();
            }
            else
            {
                textBoxForPop.Text = string.Empty;

                MessageBox.Show("Предупреждение: стек пуст");
                Logger.Log("Попытка сделать поп у пустого стека", LogType.Warning);
            }
        }
        else
        {
            MessageBox.Show("Ошибка: отсутствие алгоритма");
            Logger.Log("Попытка работы с не созданным стеком", LogType.Error);
        }
    }

    private void UpdatePictureBox() => pictureBox.Image = _drawUtility.DrawElements();

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
                UpdatePictureBox();
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
}
