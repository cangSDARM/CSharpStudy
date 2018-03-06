using System.Collections.Generic;
using System.IO;
using System.Xml;

public class XMLFileBuffer{

    private XmlDocument xml;

    /// <summary>
    /// XML·��
    /// </summary>
    private string _path;
    /// <summary>
    /// �����ı�
    /// </summary>
    private string defultText;
    
    public struct Card {
        public string type;
        public string cardName;
        public string cost;
        public string fileName;
        public string inner;
    }
    
    public enum CardTypeNum {
        EventCard = 0,
        PersonCard = 1,
        LogicalCard = 2,
        ConditionCard = 3,
        LuckyCard = 4,
        defult = 10
    }
    public string CardType(CardTypeNum index) {
        switch (index) {
            case CardTypeNum.EventCard:
                return "EventCard";
            case CardTypeNum.PersonCard:
                return "PersonCard";
            case CardTypeNum.LogicalCard:
                return "LogicalCard";
            case CardTypeNum.ConditionCard:
                return "ConditionCard";
            case CardTypeNum.LuckyCard:
                return "LuckyCard";
            default:
                return defultText;
        }
    }

    private XMLFileBuffer() {

        _path = System.Environment.CurrentDirectory + "/XMLdoc/Card_doc.xml";
        defultText = "defult";
        if (!File.Exists(_path)) {
            CreatXML();
        } else {
            LoadXML();
        }
    }

    /// <summary>
    /// ����XML
    /// </summary>
    void LoadXML() {
        XmlReaderSettings set = new XmlReaderSettings();
        //����ע���ĵ�
        set.IgnoreComments = true;
        xml.Load(XmlReader.Create(_path, set));

        XmlNodeList xmlNodeList = xml.SelectSingleNode("Card").ChildNodes;

        foreach (XmlElement xmlE in xmlNodeList) {
            if (xmlE.Name != defultText) {
                foreach (XmlElement card in xmlE.ChildNodes) {
                    Card loadCard = new Card();

                    loadCard.type = xmlE.Name;
                    loadCard.fileName = card.GetAttribute("fileName");
                    loadCard.cardName = card.GetAttribute("cardName");
                    loadCard.inner = card.InnerText;
                    loadCard.cost = card.GetAttribute("cost");
                }
            }
        }
    }


    /// <summary>
    /// ��ʼ��XML
    /// </summary>
    void CreatXML() {
        xml = new XmlDocument();

        //����XML�ĵ�����
        XmlDeclaration dec = xml.CreateXmlDeclaration("1.0","utf-8",null);
        xml.AppendChild(dec);

        //������ʼ�ڵ�
        XmlElement root = xml.CreateElement("Card");

        //����Ĭ�������ӽڵ�
        XmlElement defult = xml.CreateElement(CardType(CardTypeNum.defult));

        //���ýڵ�����
        //defult.SetAttribute("NONE","Attribute");

        AddCardToXML("This is the card's name", defultText + ".png", "card's cost", "inner text", defult);

        XmlElement eventCard = xml.CreateElement(CardType(CardTypeNum.EventCard));
        XmlElement personCard = xml.CreateElement(CardType(CardTypeNum.PersonCard));
        XmlElement logicalCard = xml.CreateElement(CardType(CardTypeNum.LogicalCard));
        XmlElement luckyCard = xml.CreateElement(CardType(CardTypeNum.LuckyCard));
        XmlElement conditionCard = xml.CreateElement(CardType(CardTypeNum.ConditionCard));

        root.AppendChild(defult);
        root.AppendChild(eventCard);
        root.AppendChild(personCard);
        root.AppendChild(logicalCard);
        root.AppendChild(luckyCard);
        root.AppendChild(conditionCard);

        xml.AppendChild(root);

        xml.Save(_path);
    }
    
    /// <summary>
    /// ���XML����
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="fileName">�ļ���</param>
    /// <param name="cost">���ѡ��¼���Ϊ-1</param>
    /// <param name="innerText">��������</param>
    /// <param name="parent">���ڵ�</param>
    public void AddCardToXML(string cardName, string fileName,string cost, string innerText, XmlElement parent) {
        XmlElement cardXML = xml.CreateElement("card");
        cardXML.SetAttribute("cost", cost);
        cardXML.SetAttribute("cardName", cardName);
        cardXML.SetAttribute("fileName", fileName);

        //��ӱ�ǩ
        //cardXML.InnerXml = "<p>inner</p>";

        cardXML.InnerText = innerText;

        parent.AppendChild(cardXML);
    }
}