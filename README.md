# Unityバージョン

Unity2018.2.21で動作確認済み

# ScriptFileGenerator

![image](https://user-images.githubusercontent.com/10010842/58764664-ff8be600-85a4-11e9-81c9-eaf320cd9319.png)

`Create>Custom>Create Script File`から設定ファイルを生成。  
ScriptFileGenerator.csに設定ファイルを代入する。  
ClassNamesに名前を入れた状態で、**ClassNamesとSuffixから生成ボタン**を押すと、  
ForlderName/Suffix以下のフォルダに  
ClassNames+Suffix+.csのフォルダを生成する  

## Scriptファイルに書き込める内容

+ using文
+ namespace
+ クラス名
+ 継承する親クラスまたはインターフェイス名
+ フィールド
+ メソッド
