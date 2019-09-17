//  /*********************************************************************************
//   *********************************************************************************
//   *********************************************************************************
//   * Produced by Skard Games										                  *
//   * Facebook: https://goo.gl/5YSrKw											      *
//   * Contact me: https://goo.gl/y5awt4								              *											
//   * Developed by Cavit Baturalp Gürdin: https://tr.linkedin.com/in/baturalpgurdin *
//   *********************************************************************************
//   *********************************************************************************
//   *********************************************************************************/

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System;

[InitializeOnLoad]
public class WelcomeInfo : EditorWindow 
{
	private const float width = 500;
	private const float height = 640;

	private const string PREFSHOWATSTARTUP = "SkardGame.PREFSHOWATSTARTUP";

	private static bool showAtStartup;

	private static GUIStyle imgHeader;

	private static bool interfaceInitialized;
	private static Texture onlineDocIcon;
	private static Texture rateIcon;
	private static Texture twitterIcon;
	private static Texture patreonIcon;
	private static Texture supportIcon;
	private static Texture facebookIcon;

	[MenuItem("Assets/Skard Info", false, 0)]
	public static void OpenWelcomeWindow(){
		GetWindow<WelcomeInfo>(true);
	}


	static WelcomeInfo(){
		EditorApplication.playmodeStateChanged -= OnPlayModeChanged;
		EditorApplication.playmodeStateChanged += OnPlayModeChanged;
		
		showAtStartup = PlayerPrefs.GetInt(PREFSHOWATSTARTUP, 1) == 1;
		
		if (showAtStartup){
			EditorApplication.update -= OpenAtStartup;
			EditorApplication.update += OpenAtStartup;
		}
	}

	static void OpenAtStartup(){
		OpenWelcomeWindow();
		EditorApplication.update -= OpenAtStartup;
	}

	static void OnPlayModeChanged(){
		EditorApplication.update -= OpenAtStartup;
		EditorApplication.playmodeStateChanged -= OnPlayModeChanged;
	}
	
	void OnEnable(){
		#if UNITY_5_3_OR_NEWER
		titleContent = new GUIContent("                                                               Welcome To Skard"); 
		#endif

		maxSize = new Vector2(width, height);
		minSize = maxSize;
	}	

	public void OnGUI(){

		InitInterface();
		GUI.Box(new Rect(0, 0, width, 60), "", imgHeader);
		GUILayoutUtility.GetRect(position.width, 64);
		GUILayout.Space(40);
		GUILayout.BeginVertical();

	
		if (Button(rateIcon,"Rate this asset","Write us a review on the asset store.")){
			Application.OpenURL(Constants.ASSETSTORE_URL);
		}

		if (Button(onlineDocIcon,"Online documentation","Read the full documentation.")){
			Application.OpenURL(Constants.ONLINE_DOC_URL);
		}

		if (Button(supportIcon,"Have any problem or question about this asset?\nWant to participate as an artist? ","Don't hesitate to write me, whenever you want.")){
			Application.OpenURL(Constants.CONTACT_URL);
		}

		if (Button(facebookIcon,"Like me on facebook to get access direct download","Be informed of the latest updates.")){
			Application.OpenURL(Constants.FACEBOOK_URL);
		}

		if (Button(twitterIcon,"Follow me on twitter to get access direct download","Be informed of the latest updates.")){
			Application.OpenURL(Constants.TWITTER_URL);
		}

		if (DonateButton(patreonIcon,"PLEASE DONATE ME","Being a student is economically hard\n   If you want me to order a meal :).")){
			Application.OpenURL(Constants.PATREON_URL);
		}
			
		GUILayout.Space(20);
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();

		bool show = GUILayout.Toggle(showAtStartup, "Show at startup");
		if (show != showAtStartup){
			showAtStartup = show;
			int i = GetInt(showAtStartup);
			PlayerPrefs.SetInt(PREFSHOWATSTARTUP, i);
			PlayerPrefs.Save();
		}
		GUILayout.EndHorizontal ();

		GUILayout.EndVertical();

	}

	int GetInt(bool b)
	{
		if(b)
			return 1;
		else
			return 0;
	}

	void InitInterface(){

		if (!interfaceInitialized){
			imgHeader = new GUIStyle();
			imgHeader.normal.background = (Texture2D)Resources.Load("skard_banner");
			imgHeader.normal.textColor = Color.white;

			onlineDocIcon = (Texture)Resources.Load("btn_documentation") as Texture;
			twitterIcon = (Texture)Resources.Load("btn_twitter") as Texture;
			rateIcon = (Texture)Resources.Load("btn_rateus") as Texture;
			supportIcon = (Texture)Resources.Load("btn_support") as Texture;
			facebookIcon = (Texture)Resources.Load("btn_facebook") as Texture;
			patreonIcon = (Texture)Resources.Load("btn_patreon") as Texture;

			interfaceInitialized = true;
		}
	}
	
	bool Button(Texture texture, string heading, string body, int space=10){

		GUILayout.BeginHorizontal();
		
		GUILayout.Space(10);
		GUILayout.Box(texture, GUIStyle.none, GUILayout.MaxWidth(48));
		
		GUILayout.BeginVertical();
		GUILayout.Space(1);
		GUILayout.Label(heading, EditorStyles.boldLabel);
		GUILayout.Label(body);
		GUILayout.EndVertical();
		
		GUILayout.EndHorizontal();
		
		var rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);
			
		bool returnValue = false;
		if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition)){
			returnValue = true;
		}
		
		GUILayout.Space(space);

		return returnValue;
	}

	bool DonateButton(Texture texture, string heading, string body, int space=10){

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace ();
		GUILayout.Box(texture, GUIStyle.none, GUILayout.MaxWidth(48));
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace ();
		GUILayout.Label(heading, EditorStyles.boldLabel);
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace ();
		GUILayout.Label(body);
		GUILayout.FlexibleSpace ();
		GUILayout.EndHorizontal();

		var rect = GUILayoutUtility.GetLastRect();
		var temp = new Rect (rect.x,rect.y-90,rect.width,rect.height+90);
		EditorGUIUtility.AddCursorRect(temp, MouseCursor.Link);

		bool returnValue = false;
		if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition)){
			returnValue = true;
		}

		return returnValue;
	}
}
#endif
