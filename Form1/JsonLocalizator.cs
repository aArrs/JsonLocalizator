using System.Xml;
using GTranslate.Translators;
using Newtonsoft.Json.Linq;
using WinFormsApp2.Interfaces;

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
        private readonly ICreateDirectory _createDirectory;
        private readonly ICreateResx _createResx;
        
        List<Control> labelList = new List<Control>();
        List<Control> immutTextBoxList = new List<Control>();
        List<Control> textBoxList = new List<Control>();
        JObject sourceStrings = null;
        JObject tempStrings = null;
        private string language = "be";
        JObject translatedStrings = null;
        private List<JProperty> sourceList = new List<JProperty>();
        private List<JProperty> translatedList = new List<JProperty>();
        private List<KeyValuePair<string, string>> resxTranslatedList = new List<KeyValuePair<string, string>>();
        private List<KeyValuePair<string, string>> resxToSave = new List<KeyValuePair<string, string>>();

        
        public JsonLocalizator(IGetFileText getFileText, ICast cast, ITranslate translate, ICreateJson createJson,
            IViewList viewList, IUpdateList updateList, IAddControls addControls, IClearControls clearControls, ICreateDirectory createDirectory, ICreateResx createResx)
        {
            _getFileText = getFileText;
            _cast = cast;
            _addControls = addControls;
            _clearControls = clearControls;
            _translate = translate;
            _createJson = createJson;
            _viewList = viewList;
            _updateList = updateList;
            _createDirectory = createDirectory;
            _createResx = createResx;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            panel1.SuspendLayout();
            panel1.AutoScrollPosition = new Point(0, 0);
            _clearControls.RemoveControls(labelList, panel1);
            _clearControls.RemoveControls(immutTextBoxList, panel1);
            _clearControls.RemoveControls(textBoxList, panel1);
            sourceList.Clear();
            sourceList.TrimExcess();
            textBoxList.Clear();
            textBoxList.TrimExcess();
            immutTextBoxList.Clear();
            immutTextBoxList.TrimExcess();
            labelList.Clear();
            labelList.TrimExcess();
            translatedList.Clear();
            translatedList.TrimExcess();
            resxTranslatedList.Clear();
            resxTranslatedList.TrimExcess();
            resxToSave.Clear();
            resxToSave.TrimExcess();
            foreach (Control control in panel1.Controls)
            {
                control.Dispose();
            }
            try
            {
                _getFileText.GetText(openFile);
                if (_getFileText.fileExtension == ".json")
                {
                    sourceStrings = _cast.GetJObject(_getFileText.fileText);
                    if (sourceStrings.Count != 0)
                    {
                        sourceList.Clear();
                        sourceList.TrimExcess();
                    }

                    sourceList = _viewList.ValueViewer(sourceStrings, sourceList);

                    _addControls.AddLabel(panel1, sourceList, labelList);
                    _addControls.AddImmutableTextBox(panel1, sourceList, immutTextBoxList);
                }
                else
                {
                    _addControls.AddResxLabel(panel1, _getFileText.resources, labelList);
                    _addControls.AddResxImmutableTextBox(panel1, _getFileText.resources, immutTextBoxList);
                }
                
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Ошибка: Файл не найден.");
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка: Нет прав доступа к файлу.");
            }
            catch (XmlException)
            {
                MessageBox.Show("Ошибка: Файл поврежден.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            panel1.ResumeLayout();
        }
        
        private async void button2_Click(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 0);
            panel1.AutoScrollPosition = new Point(0, panel1.AutoScrollPosition.Y);
           

            if (translatedList.Count != 0)
            {
                translatedList.Clear();
                translatedList.TrimExcess();
                resxTranslatedList.Clear();
                resxTranslatedList.TrimExcess();
                resxToSave.Clear();
                resxToSave.TrimExcess();
            }
            translatedStrings = null;
            _clearControls.RemoveControls(textBoxList, panel1);
            if (_getFileText.fileExtension == ".json")
            {
                try
                {
                    Task task = _translate.TranslateJsonYa(translatorYandex, sourceStrings, language);
                
                    if (!task.IsCompleted)
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        panel1.AutoScroll = false;
                    }

                    translatedStrings = await _translate.TranslateJsonYa(translatorYandex, sourceStrings, language);
                    translatedList = _viewList.ValueViewer(translatedStrings, translatedList);
                    _addControls.AddTextBox(panel1, translatedList, textBoxList);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //cts.Cancel();
                
                }
                finally
                {
                    panel1.AutoScroll = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
            }
            else
            {
                try
                {
                    Task task = _translate.TranslateResxYa(translatorYandex, _getFileText.resources, language);
                
                    if (!task.IsCompleted)
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        panel1.AutoScroll = false;
                    }

                    resxTranslatedList = await _translate.TranslateResxYa(translatorYandex, _getFileText.resources, language);
                    _addControls.AddResxTextBox(panel1, resxTranslatedList, textBoxList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //cts.Cancel();
                
                }
                finally
                {
                    panel1.AutoScroll = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
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
                _createDirectory.CreateDirectory("be");
                _createDirectory.CreateDirectory("resx_be");
                _createDirectory.CreateDirectory("en");
                _createDirectory.CreateDirectory("resx_en");
                
                if (textBoxList.Count > 0)
                {
                    if(_getFileText.fileExtension == ".json")
                    {
                        for (int i = 0; i < textBoxList.Count; i++)
                        {
                            _updateList.UpdateList(translatedList, textBoxList[i], i);
                        }

                        _updateList.UpdateTranslation(translatedStrings, translatedList);
                        _createJson.CreateJson(translatedStrings.ToString(), _getFileText.fileName, language);
                    }
                    else
                    {
                        for (int i = 0; i < textBoxList.Count; i++)
                        {
                            _updateList.UpdateResxList(resxTranslatedList, resxToSave, textBoxList[i], i);
                        }
                        _createResx.CreateResx(resxToSave, _getFileText.fileName, language, _getFileText.tempFilePath);
                    }
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
            _clearControls.RemoveControls(labelList, panel1);
            _clearControls.RemoveControls(immutTextBoxList, panel1);
            _clearControls.RemoveControls(textBoxList, panel1);
            comboBox1.SelectedItem = 1;
            comboBox1.SelectedIndex = 1;
            language = "be";
            translatedStrings = null;
            sourceStrings = null;
            sourceList.Clear();
            sourceList.TrimExcess();
            textBoxList.Clear();
            textBoxList.TrimExcess();
            immutTextBoxList.Clear();
            immutTextBoxList.TrimExcess();
            labelList.Clear();
            labelList.TrimExcess();
            translatedList.Clear();
            translatedList.TrimExcess();
            resxTranslatedList.Clear();
            resxTranslatedList.TrimExcess();
            resxToSave.Clear();
            resxToSave.TrimExcess();
            panel1.ResumeLayout();
        }
        private void JsonTranslator_Load(object sender, EventArgs e)
        {
        }
    }
