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
		Messenger.Message("MUY BIEN!!!", 0.01f, Color.green, true, true);
		if (correct) {
			Debug.Log ("Muy bien!");
			if (GameObject.Find("CofreHanoi").transform.position.y > -5.0f)
				GameObject.Find("CofreHanoi").transform.position -= new Vector3(0, 0.2f, 0);
			else {
				GameObject.Find("CofreHanoi").transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("openNow", true);
				correct = false;
				Hanoi.active = true;
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
			
			case "he":
				return 002;
			
			case "li":
				return 003;
			
			case "be":
				return 004;
			
			case "b":
				return 005;
			
			case "c":
				return 006;
			
			case "n":
				return 007;
			
			case "o":
				return 008;
			
			case "f":
				return 009;
			
			case "ne":
				return 010;
			
			case "na":
				return 011;
			
			case "mg":
				return 012;
			
			case "al":
				return 013;
			
			case "si":
				return 014;
			
			case "p":
				return 015;
			
			case "s":
				return 016;
			
			case "cl":
				return 017;
			
			case "ar":
				return 018;
			
			case "k":
				return 019;
			
			case "ca":
				return 020;
			
			case "sc":
				return 021;
			
			case "ti":
				return 022;
			
			case "v":
				return 023;
			
			case "cr":
				return 024;
			
			case "mn":
				return 025;
			
			case "fe":
				return 026;
			
			case "co":
				return 027;
			
			case "ni":
				return 028;
			
			case "cu":
				return 029;
			
			case "zn":
				return 030;
			
			case "ga":
				return 031;
			
			case "ge":
				return 032;
			
			case "as":
				return 033;
			
			case "se":
				return 034;
			
			case "br":
				return 035;
			
			case "kr":
				return 036;
			
			case "rb":
				return 037;
			
			case "sr":
				return 038;
			
			case "y":
				return 039;
			
			case "zr":
				return 040;
			
			case "nb":
				return 041;
			
			case "mo":
				return 042;
			
			case "tc":
				return 043;
			
			case "ru":
				return 044;
			
			case "rh":
				return 045;
			
			case "pd":
				return 046;
			
			case "ag":
				return 047;
			
			case "cd":
				return 048;
			
			case "in":
				return 049;
			
			case "sn":
				return 050;
			
			case "sb":
				return 051;
			
			case "te":
				return 052;
			
			case "i":
				return 053;
			
			case "xe":
				return 054;
			
			case "cs":
				return 055;
			
			case "ba":
				return 056;
			
			case "la":
				return 057;
			
			case "ce":
				return 058;
			
			case "pr":
				return 059;
			
			case "nd":
				return 060;
			
			case "pm":
				return 061;
			
			case "sm":
				return 062;
			
			case "eu":
				return 063;
			
			case "gd":
				return 064;
			
			case "tb":
				return 065;
			
			case "dy":
				return 066;
			
			case "ho":
				return 067;
			
			case "er":
				return 068;
			
			case "tm":
				return 069;
			
			case "yb":
				return 070;
			
			case "lu":
				return 071;
			
			case "hf":
				return 072;
			
			case "ta":
				return 073;
			
			case "w":
				return 074;
			
			case "re":
				return 075;
			
			case "os":
				return 076;
			
			case "ir":
				return 077;
			
			case "pt":
				return 078;
			
			case "au":
				return 079;
			
			case "hg":
				return 080;
			
			case "tl":
				return 081;
			
			case "pb":
				return 082;
			
			case "bi":
				return 083;
			
			case "po":
				return 084;
			
			case "at":
				return 085;
			
			case "rn":
				return 086;
			
			case "fr":
				return 087;
			
			case "ra":
				return 088;
			
			case "ac":
				return 089;
			
			case "th":
				return 090;
			
			case "pa":
				return 091;
			
			case "u":
				return 092;
			
			case "np":
				return 093;
			
			case "pu":
				return 094;
			
			case "am":
				return 095;
			
			case "cm":
				return 096;
			
			case "bk":
				return 097;
			
			case "cf":
				return 098;
			
			case "es":
				return 099;
			
			case "fm":
				return 100;
			
			case "md":
				return 101;
			
			case "no":
				return 102;
			
			case "lr":
				return 103;
			
			case "rf":
				return 104;
			
			case "db":
				return 105;
			
			case "sg":
				return 106;
			
			case "bh":
				return 107;
			
			case "hs":
				return 108;
			
			case "mt":
				return 109;
			
			case "ds":
				return 110;
			
			case "rg":
				return 111;
			
			case "uub":
				return 112;
			
			case "uut":
				return 113;
			
			case "uuq":
				return 114;
			
			case "uup":
				return 115;
			
			case "uuh":
				return 116;
			
			case "uus":
				return 117;
			
			case "uuo":
				return 118;
			
			default:
				return 000;
			
		}
	}

	private string PeriodicTableCodeToStringSymbol(int n) {
		switch (n) {
			case 001:
				return "h";
				
			case 002:
				return "he";
				
			case 003:
				return "li";
				
			case 004:
				return "be";
				
			case 005:
				return "b";
				
			case 006:
				return "c";
				
			case 007:
				return "n";
				
			case 008:
				return "o";
				
			case 009:
				return "f";
				
			case 010:
				return "ne";
				
			case 011:
				return "na";
				
			case 012:
				return "mg";
				
			case 013:
				return "al";
				
			case 014:
				return "si";
				
			case 015:
				return "p";
				
			case 016:
				return "s";
				
			case 017:
				return "cl";
				
			case 018:
				return "ar";
				
			case 019:
				return "k";
				
			case 020:
				return "ca";
				
			case 021:
				return "sc";
				
			case 022:
				return "ti";
				
			case 023:
				return "v";
				
			case 024:
				return "cr";
				
			case 025:
				return "mn";
				
			case 026:
				return "fe";
				
			case 027:
				return "co";
				
			case 028:
				return "ni";
				
			case 029:
				return "cu";
				
			case 030:
				return "zn";
				
			case 031:
				return "ga";
				
			case 032:
				return "ge";
				
			case 033:
				return "as";
				
			case 034:
				return "se";
				
			case 035:
				return "br";
				
			case 036:
				return "kr";
				
			case 037:
				return "rb";
				
			case 038:
				return "sr";
				
			case 039:
				return "y";
				
			case 040:
				return "zr";
				
			case 041:
				return "nb";
				
			case 042:
				return "mo";
				
			case 043:
				return "tc";
				
			case 044:
				return "ru";
				
			case 045:
				return "rh";
				
			case 046:
				return "pd";
				
			case 047:
				return "ag";
				
			case 048:
				return "cd";
				
			case 049:
				return "in";
				
			case 050:
				return "sn";
				
			case 051:
				return "sb";
				
			case 052:
				return "te";
				
			case 053:
				return "i";
				
			case 054:
				return "xe";
				
			case 055:
				return "cs";
				
			case 056:
				return "ba";
				
			case 057:
				return "la";
				
			case 058:
				return "ce";
				
			case 059:
				return "pr";
				
			case 060:
				return "nd";
				
			case 061:
				return "pm";
				
			case 062:
				return "sm";
				
			case 063:
				return "eu";
				
			case 064:
				return "gd";
				
			case 065:
				return "tb";
				
			case 066:
				return "dy";
				
			case 067:
				return "ho";
				
			case 068:
				return "er";
				
			case 069:
				return "tm";
				
			case 070:
				return "yb";
				
			case 071:
				return "lu";
				
			case 072:
				return "hf";
				
			case 073:
				return "ta";
				
			case 074:
				return "w";
				
			case 075:
				return "re";
				
			case 076:
				return "os";
				
			case 077:
				return "ir";
				
			case 078:
				return "pt";
				
			case 079:
				return "au";
				
			case 080:
				return "hg";
				
			case 081:
				return "tl";
				
			case 082:
				return "pb";
				
			case 083:
				return "bi";
				
			case 084:
				return "po";
				
			case 085:
				return "at";
				
			case 086:
				return "rn";
				
			case 087:
				return "fr";
				
			case 088:
				return "ra";
				
			case 089:
				return "ac";
				
			case 090:
				return "th";
				
			case 091:
				return "pa";
				
			case 092:
				return "u";
				
			case 093:
				return "np";
				
			case 094:
				return "pu";
				
			case 095:
				return "am";
				
			case 096:
				return "cm";
				
			case 097:
				return "bk";
				
			case 098:
				return "cf";
				
			case 099:
				return "es";
				
			case 100:
				return "fm";
				
			case 101:
				return "md";
				
			case 102:
				return "no";
				
			case 103:
				return "lr";
				
			case 104:
				return "rf";
				
			case 105:
				return "db";
				
			case 106:
				return "sg";
				
			case 107:
				return "bh";
				
			case 108:
				return "hs";
				
			case 109:
				return "mt";
				
			case 110:
				return "ds";
				
			case 111:
				return "rg";
				
			case 112:
				return "uub";
				
			case 113:
				return "uut";
				
			case 114:
				return "uuq";
				
			case 115:
				return "uup";
				
			case 116:
				return "uuh";
				
			case 117:
				return "uus";
				
			case 118:
				return "uuo";
				
			default:
				return "-";
			
		}
	}
}
