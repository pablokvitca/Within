using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayBehaveviour : MonoBehaviour {

	private string inputString = "";
	private int[] input = new int[5];

	public string desiredresult = "cofre";

	private string prev = ""; //debug

	private bool correct = false;

	// Use this for initialization
	void Start () {
		input[0] = -1;
		input[1] = -1;
		input[2] = -1;
		input[3] = -1;
		input[4] = -1;
	}
	
	// Update is called once per frame
	void Update () {
		inputString = "";
		for (int i = 0; i < input.Length; i++) {
			if (input[i] < 0 || input[i] > 9)
				inputString += "-";
			else
				inputString += input[i].ToString();
			if (i + 1 < input.Length)
				inputString += " ";
		}
		if (prev != inputString) { //debug
			Debug.Log("Input string is: " + inputString);
			prev = inputString;
		}
		//show string on display
		this.GetComponent<TextMesh>().text = inputString;

		if (correct) Cofre();
	}

	public void ChangeInput(int pos, int c) {
		Debug.Log (pos.ToString ());
		if (c >= 0 && 9 >= c && pos < 5 && pos > -1) input[pos] = c;
		else if (c == 10 && pos >= input.Length - 1)
			if (IsCorrect(desiredresult, input)) correct = true;
			else Debug.Log("Wrong code");
		else if (c == 11 && pos > -1)
			try { input[pos] = -1; } catch {}
	}

	private void Cofre() {
		//Cae cofre
		//Escena Torres de Hanoi
		Debug.Log ("Muy bien!");
		if (correct) {
			if (GameObject.Find("CofreHanoi").transform.position.y >= 1.0f)
				GameObject.Find("CofreHanoi").transform.position -= new Vector3(0, 0.1f, 0);
			else {
				GameObject.Find("CofreHanoi").transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("openNow", true);
				correct = false;
			}
		}
	}

	private bool IsCorrect(string desired, int[] given) {
		int[] a = new int[5] { 2, 7, 9, 7, 5};
		int[] b = new int[5] { 6, 8, 9, 7, 5};
		bool abool = true;
		for (int i = 0; i < a.Length; i++)
			if (given[i] != a[i])
				abool = false;
		bool bbool = true;
		for (int i = 0; i < b.Length; i++)
			if (given[i] != b[i])
				bbool = false;
		return (abool || bbool);
		/*Debug.Log("given to string: " + given.ToString());
		List<string> symbols = stringer(desired);
		foreach (string element in symbols)
			if  (crazy(element) == given)
				return true;
		return false;*/
		//return GeneratePosibleCodes(desired).Exists(p => p == given);
	}

	private int[] crazy(string sym) {
		for (int i = 0; i < input.Length; i++)
			if (input[i] == 0) {
				try {
					int n = StringSymbolToPeriodicTableNumber(sym);
					input[i] = int.Parse(n.ToString().Substring(0,1));
					if (n.ToString().Length == 2) input[i + 1] = int.Parse(n.ToString().Substring(1,1));
					if (n.ToString().Length == 2) input[i + 2] = int.Parse(n.ToString().Substring(2,1));
				} catch {}
			}
		return input;
	}

	private List<string> stringer(string input) {
		List<string> temp = new List<string>();
		for (int i = 0; i < input.Length; i++)
			for (int j = 0; j + i < input.Length + 1; j++)
				if (input.Substring(i, j) != "" && input.Substring(i, j) != null)
					try { temp.Add(input.Substring(i,j)); } catch {}
		return temp;
	}

	private List<int[]> GeneratePosibleCodes(string desired) {
		List<int[]> res = new List<int[]>();
		for (int i = 0; i < 120; i++)
			for (int j = 0; j < 120; j++)
				for (int k = 0; k < 120; k++)
					for (int l = 0; l < 120; l++)
						for (int m = 0; m < 120; m++) {
							string temp = "";
							temp += PeriodicTableCodeToStringSymbol(i);
							temp += PeriodicTableCodeToStringSymbol(j);
							temp += PeriodicTableCodeToStringSymbol(k);
							temp += PeriodicTableCodeToStringSymbol(l);
							temp += PeriodicTableCodeToStringSymbol(m);
							if (temp == desired)
								res.Add(new int[5] { i , j , k , l , m});
						}
		return res;
	}

	private int StringSymbolToPeriodicTableNumber(string sym) {
		/*int i = 0;
		while (i < 120 && PeriodicTableCodeToStringSymbol(i) != sym)
			i++;
		return i;*/
		switch (sym) {
			case "h":
				return 001;
			break;
			case "he":
				return 002;
			break;
			case "li":
				return 003;
			break;
			case "be":
				return 004;
			break;
			case "b":
				return 005;
			break;
			case "c":
				return 006;
			break;
			case "n":
				return 007;
			break;
			case "o":
				return 008;
			break;
			case "f":
				return 009;
			break;
			case "ne":
				return 010;
			break;
			case "na":
				return 011;
			break;
			case "mg":
				return 012;
			break;
			case "al":
				return 013;
			break;
			case "si":
				return 014;
			break;
			case "p":
				return 015;
			break;
			case "s":
				return 016;
			break;
			case "cl":
				return 017;
			break;
			case "ar":
				return 018;
			break;
			case "k":
				return 019;
			break;
			case "ca":
				return 020;
			break;
			case "sc":
				return 021;
			break;
			case "ti":
				return 022;
			break;
			case "v":
				return 023;
			break;
			case "cr":
				return 024;
			break;
			case "mn":
				return 025;
			break;
			case "fe":
				return 026;
			break;
			case "co":
				return 027;
			break;
			case "ni":
				return 028;
			break;
			case "cu":
				return 029;
			break;
			case "zn":
				return 030;
			break;
			case "ga":
				return 031;
			break;
			case "ge":
				return 032;
			break;
			case "as":
				return 033;
			break;
			case "se":
				return 034;
			break;
			case "br":
				return 035;
			break;
			case "kr":
				return 036;
			break;
			case "rb":
				return 037;
			break;
			case "sr":
				return 038;
			break;
			case "y":
				return 039;
			break;
			case "zr":
				return 040;
			break;
			case "nb":
				return 041;
			break;
			case "mo":
				return 042;
			break;
			case "tc":
				return 043;
			break;
			case "ru":
				return 044;
			break;
			case "rh":
				return 045;
			break;
			case "pd":
				return 046;
			break;
			case "ag":
				return 047;
			break;
			case "cd":
				return 048;
			break;
			case "in":
				return 049;
			break;
			case "sn":
				return 050;
			break;
			case "sb":
				return 051;
			break;
			case "te":
				return 052;
			break;
			case "i":
				return 053;
			break;
			case "xe":
				return 054;
			break;
			case "cs":
				return 055;
			break;
			case "ba":
				return 056;
			break;
			case "la":
				return 057;
			break;
			case "ce":
				return 058;
			break;
			case "pr":
				return 059;
			break;
			case "nd":
				return 060;
			break;
			case "pm":
				return 061;
			break;
			case "sm":
				return 062;
			break;
			case "eu":
				return 063;
			break;
			case "gd":
				return 064;
			break;
			case "tb":
				return 065;
			break;
			case "dy":
				return 066;
			break;
			case "ho":
				return 067;
			break;
			case "er":
				return 068;
			break;
			case "tm":
				return 069;
			break;
			case "yb":
				return 070;
			break;
			case "lu":
				return 071;
			break;
			case "hf":
				return 072;
			break;
			case "ta":
				return 073;
			break;
			case "w":
				return 074;
			break;
			case "re":
				return 075;
			break;
			case "os":
				return 076;
			break;
			case "ir":
				return 077;
			break;
			case "pt":
				return 078;
			break;
			case "au":
				return 079;
			break;
			case "hg":
				return 080;
			break;
			case "tl":
				return 081;
			break;
			case "pb":
				return 082;
			break;
			case "bi":
				return 083;
			break;
			case "po":
				return 084;
			break;
			case "at":
				return 085;
			break;
			case "rn":
				return 086;
			break;
			case "fr":
				return 087;
			break;
			case "ra":
				return 088;
			break;
			case "ac":
				return 089;
			break;
			case "th":
				return 090;
			break;
			case "pa":
				return 091;
			break;
			case "u":
				return 092;
			break;
			case "np":
				return 093;
			break;
			case "pu":
				return 094;
			break;
			case "am":
				return 095;
			break;
			case "cm":
				return 096;
			break;
			case "bk":
				return 097;
			break;
			case "cf":
				return 098;
			break;
			case "es":
				return 099;
			break;
			case "fm":
				return 100;
			break;
			case "md":
				return 101;
			break;
			case "no":
				return 102;
			break;
			case "lr":
				return 103;
			break;
			case "rf":
				return 104;
			break;
			case "db":
				return 105;
			break;
			case "sg":
				return 106;
			break;
			case "bh":
				return 107;
			break;
			case "hs":
				return 108;
			break;
			case "mt":
				return 109;
			break;
			case "ds":
				return 110;
			break;
			case "rg":
				return 111;
			break;
			case "uub":
				return 112;
			break;
			case "uut":
				return 113;
			break;
			case "uuq":
				return 114;
			break;
			case "uup":
				return 115;
			break;
			case "uuh":
				return 116;
			break;
			case "uus":
				return 117;
			break;
			case "uuo":
				return 118;
			break;
			default:
				return 000;
			break;
		}
	}

	private string PeriodicTableCodeToStringSymbol(int n) {
		switch (n) {
			case 001:
				return "h";
				break;
			case 002:
				return "he";
				break;
			case 003:
				return "li";
				break;
			case 004:
				return "be";
				break;
			case 005:
				return "b";
				break;
			case 006:
				return "c";
				break;
			case 007:
				return "n";
				break;
			case 008:
				return "o";
				break;
			case 009:
				return "f";
				break;
			case 010:
				return "ne";
				break;
			case 011:
				return "na";
				break;
			case 012:
				return "mg";
				break;
			case 013:
				return "al";
				break;
			case 014:
				return "si";
				break;
			case 015:
				return "p";
				break;
			case 016:
				return "s";
				break;
			case 017:
				return "cl";
				break;
			case 018:
				return "ar";
				break;
			case 019:
				return "k";
				break;
			case 020:
				return "ca";
				break;
			case 021:
				return "sc";
				break;
			case 022:
				return "ti";
				break;
			case 023:
				return "v";
				break;
			case 024:
				return "cr";
				break;
			case 025:
				return "mn";
				break;
			case 026:
				return "fe";
				break;
			case 027:
				return "co";
				break;
			case 028:
				return "ni";
				break;
			case 029:
				return "cu";
				break;
			case 030:
				return "zn";
				break;
			case 031:
				return "ga";
				break;
			case 032:
				return "ge";
				break;
			case 033:
				return "as";
				break;
			case 034:
				return "se";
				break;
			case 035:
				return "br";
				break;
			case 036:
				return "kr";
				break;
			case 037:
				return "rb";
				break;
			case 038:
				return "sr";
				break;
			case 039:
				return "y";
				break;
			case 040:
				return "zr";
				break;
			case 041:
				return "nb";
				break;
			case 042:
				return "mo";
				break;
			case 043:
				return "tc";
				break;
			case 044:
				return "ru";
				break;
			case 045:
				return "rh";
				break;
			case 046:
				return "pd";
				break;
			case 047:
				return "ag";
				break;
			case 048:
				return "cd";
				break;
			case 049:
				return "in";
				break;
			case 050:
				return "sn";
				break;
			case 051:
				return "sb";
				break;
			case 052:
				return "te";
				break;
			case 053:
				return "i";
				break;
			case 054:
				return "xe";
				break;
			case 055:
				return "cs";
				break;
			case 056:
				return "ba";
				break;
			case 057:
				return "la";
				break;
			case 058:
				return "ce";
				break;
			case 059:
				return "pr";
				break;
			case 060:
				return "nd";
				break;
			case 061:
				return "pm";
				break;
			case 062:
				return "sm";
				break;
			case 063:
				return "eu";
				break;
			case 064:
				return "gd";
				break;
			case 065:
				return "tb";
				break;
			case 066:
				return "dy";
				break;
			case 067:
				return "ho";
				break;
			case 068:
				return "er";
				break;
			case 069:
				return "tm";
				break;
			case 070:
				return "yb";
				break;
			case 071:
				return "lu";
				break;
			case 072:
				return "hf";
				break;
			case 073:
				return "ta";
				break;
			case 074:
				return "w";
				break;
			case 075:
				return "re";
				break;
			case 076:
				return "os";
				break;
			case 077:
				return "ir";
				break;
			case 078:
				return "pt";
				break;
			case 079:
				return "au";
				break;
			case 080:
				return "hg";
				break;
			case 081:
				return "tl";
				break;
			case 082:
				return "pb";
				break;
			case 083:
				return "bi";
				break;
			case 084:
				return "po";
				break;
			case 085:
				return "at";
				break;
			case 086:
				return "rn";
				break;
			case 087:
				return "fr";
				break;
			case 088:
				return "ra";
				break;
			case 089:
				return "ac";
				break;
			case 090:
				return "th";
				break;
			case 091:
				return "pa";
				break;
			case 092:
				return "u";
				break;
			case 093:
				return "np";
				break;
			case 094:
				return "pu";
				break;
			case 095:
				return "am";
				break;
			case 096:
				return "cm";
				break;
			case 097:
				return "bk";
				break;
			case 098:
				return "cf";
				break;
			case 099:
				return "es";
				break;
			case 100:
				return "fm";
				break;
			case 101:
				return "md";
				break;
			case 102:
				return "no";
				break;
			case 103:
				return "lr";
				break;
			case 104:
				return "rf";
				break;
			case 105:
				return "db";
				break;
			case 106:
				return "sg";
				break;
			case 107:
				return "bh";
				break;
			case 108:
				return "hs";
				break;
			case 109:
				return "mt";
				break;
			case 110:
				return "ds";
				break;
			case 111:
				return "rg";
				break;
			case 112:
				return "uub";
				break;
			case 113:
				return "uut";
				break;
			case 114:
				return "uuq";
				break;
			case 115:
				return "uup";
				break;
			case 116:
				return "uuh";
				break;
			case 117:
				return "uus";
				break;
			case 118:
				return "uuo";
				break;
			default:
				return "-";
			break;
		}
	}
}
