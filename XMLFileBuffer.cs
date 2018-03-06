using System.Collections.Generic;
using System.IO;
using System.Xml;

public class XMLFileBuffer{

    private XmlDocument xml;

    /// <summary>
    /// XML路径
    /// </summary>
    private string _path;
    /// <summary>
    /// 测试文本
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
    /// 加载XML
    /// </summary>
    void LoadXML() {
        XmlReaderSettings set = new XmlReaderSettings();
        //忽视注释文档
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
    /// 初始化XML
    /// </summary>
    void CreatXML() {
        xml = new XmlDocument();

        //创建XML文档属性
        XmlDeclaration dec = xml.CreateXmlDeclaration("1.0","utf-8",null);
        xml.AppendChild(dec);

        //创建初始节点
        XmlElement root = xml.CreateElement("Card");

        //创建默认样板子节点
        XmlElement defult = xml.CreateElement(CardType(CardTypeNum.defult));

        //设置节点属性
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
    /// 添加XML数据
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="fileName">文件名</param>
    /// <param name="cost">花费。事件牌为-1</param>
    /// <param name="innerText">卡牌文字</param>
    /// <param name="parent">父节点</param>
    public void AddCardToXML(string cardName, string fileName,string cost, string innerText, XmlElement parent) {
        XmlElement cardXML = xml.CreateElement("card");
        cardXML.SetAttribute("cost", cost);
        cardXML.SetAttribute("cardName", cardName);
        cardXML.SetAttribute("fileName", fileName);

        //添加标签
        //cardXML.InnerXml = "<p>inner</p>";

        cardXML.InnerText = innerText;

        parent.AppendChild(cardXML);
    }
}