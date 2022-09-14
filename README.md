# TextPad

- Open File
```
private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "";

            openFileDialog1.Filter = "Text File (*.txt) | *.txt| All File (*.*) | *.*";
            openFileDialog1.InitialDirectory = @"Documents";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog1.SafeFileName + " - TextPad"; 
                //1. "this" refer to this form.
                //2. "openFileDialog2.SafeFileName" to display only filename
                sr = new StreamReader(openFileDialog1.FileName.ToString()); 
                text = sr.ReadToEnd();
                txtArea.Text = text;
                sr.Close();
            }
        }
```

- Save File
```
        public void saveTxtFile()
        {
            string text = "";

            saveFileDialog1.Filter = "Text File (*.txt) | *.txt| All File (*.*) | *.*";
            saveFileDialog1.InitialDirectory = @"Documents";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog1.FileName);
                text = txtArea.Text.ToString();
                sw.Write(text);
                sw.Close();
            }

            //To Display Only Saved File Name
            string fi = Path.GetFileName(saveFileDialog1.FileName + " - TextPad");
            this.Text = fi;
        }
```

### App Previews

![Preview - 1](https://github.com/yarzardhiyit/yarzardhiyit/blob/main/txtpad.png)

- Thanks.
