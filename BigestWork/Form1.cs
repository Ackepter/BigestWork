using BigestWork.Draw;
using BigestWork.Loggers;
using BigestWork.Logic;

namespace BigestWork;

public partial class Form1 : System.Windows.Forms.Form
{
    private Logger logger = new Logger();
    private DrawUtility _draw;

    private ActionWithAlgorythm _action;

    public Form1()
    {
        InitializeComponent();
    }

    
    private void addButton_Click(object sender, EventArgs e)
    {
        _action = new ActionWithAlgorythm();

        _action.Configure(new Setting());
    }

    private void pushButton_Click(object sender, EventArgs e)
    {
        if (_action is not null)
        {
            _action.Push(textBoxForPush.Text);
        }
        else
        {
            logger.Log("Класс работы с алгоритмом не создан!", LogType.Error);
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
            }
            else
            {
                textBoxForPop.Text = string.Empty;
            }
        }
        else
        {
            logger.Log("Класс работы с алгоритмом не создан!", LogType.Error);
        }
    }
}
