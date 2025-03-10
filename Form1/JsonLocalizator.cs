using GTranslate.Translators;
using Newtonsoft.Json.Linq;
using WinFormsApp2.Classes;
using WinFormsApp2.Interfaces;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp2;

    partial class JsonLocalizator : Form
    {
        YandexTranslator translatorYandex = new YandexTranslator();

        private readonly IGetFileText _getFileText;
        private readonly ICast _cast;
        private readonly ITranslate _translate;
        private readonly ICreateJson _createJson;
        private readonly IViewList _viewList;
        private readonly IUpdateList _updateList;
        private readonly IAddControls _addControls;
        private readonly IClearControls _clearControls;
        
        List<Control> controlsToRemove = new List<Control>();
        List<Control> controlsToRemoveTranslate = new List<Control>();
        JObject sourceStrings = null;
        JObject tempStrings = null;
        private string language = "be";
        JObject translatedStrings = null;
        private List<JProperty> sourceList = new List<JProperty>();
        private List<JProperty> translatedList = new List<JProperty>();

        
        public JsonLocalizator(IGetFileText getFileText, ICast cast, ITranslate translate, ICreateJson createJson,
            IViewList viewList, IUpdateList updateList, IAddControls addControls, IClearControls clearControls)
        {
            _getFileText = getFileText;
            _cast = cast;
            _addControls = addControls;
            _clearControls = clearControls;
            _translate = translate;
            _createJson = createJson;
            _viewList = viewList;
            _updateList = updateList;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            _clearControls.RemoveControls(controlsToRemove, flowLayoutPanel1);
            _clearControls.RemoveControls(controlsToRemove, flowLayoutPanel2);
            _clearControls.RemoveControls(controlsToRemoveTranslate, flowLayoutPanel3);
            try
            {
                sourceStrings = _cast.GetJObject(_getFileText.GetText());
                if (sourceStrings.Count != 0)
                {
                    sourceList.Clear();
                    sourceList.TrimExcess();
                }

                sourceList = _viewList.ValueViewer(sourceStrings, sourceList);

                _addControls.AddLabel(flowLayoutPanel1, panel1, sourceList, controlsToRemove);
                _addControls.AddImmutableTextBox(flowLayoutPanel2, panel1, sourceList, controlsToRemove);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            panel1.ResumeLayout();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            Task task = _translate.TranslateJsonYa(translatorYandex, sourceStrings, language);
            if (translatedList.Count != 0)
            {
                translatedList.Clear();
                translatedList.TrimExcess();
            }
            translatedStrings = null;
            _clearControls.RemoveControls(controlsToRemoveTranslate, flowLayoutPanel3);
            /*controlsToRemoveTranslate.Clear();
            controlsToRemoveTranslate.TrimExcess();*/
            try
            {
                if (!task.IsCompleted)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                translatedStrings = await _translate.TranslateJsonYa(translatorYandex, sourceStrings, language);
                translatedList = _viewList.ValueViewer(translatedStrings, translatedList);
                _addControls.AddTextBox(flowLayoutPanel3, panel1, translatedList, controlsToRemoveTranslate);
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Английский")
                    language = "en";
                else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Белорусский")
                    language = "be";
                else
                    language = null;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (flowLayoutPanel3.Controls.Count > 0)
                {
                    for (int i = 0; i < flowLayoutPanel3.Controls.Count; i++)
                    {
                        _updateList.UpdateList(translatedList, flowLayoutPanel3.Controls[i], i);
                    }

                    _updateList.UpdateTranslation(translatedStrings, translatedList);
                    _createJson.CreateJson(translatedStrings.ToString(), _getFileText.fileName, language);
                }
                else
                {
                    throw new Exception("Переведите файл");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.SuspendLayout();
            _clearControls.RemoveControls(controlsToRemoveTranslate, flowLayoutPanel3);
            _clearControls.RemoveControls(controlsToRemove, flowLayoutPanel2);
            _clearControls.RemoveControls(controlsToRemove, flowLayoutPanel1);
            comboBox1.SelectedIndex = 0;
            language = null;
            translatedStrings = null;
            sourceStrings = null;
            sourceList.Clear();
            sourceList.TrimExcess();
            translatedList.Clear();
            translatedList.TrimExcess();
            panel1.ResumeLayout();
        }
        private void JsonTranslator_Load(object sender, EventArgs e)
        {
        }
    }
