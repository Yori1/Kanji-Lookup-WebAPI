# KanjiRenshuuWebAPI
An easy to use web API that uses a database created from the Tatoeba sentence database in combination with the MeCab class library to allow the user to look up Japanese sentences with detailed reading information. The API is also being hosted on Azure on https://kanjiapi.azurewebsites.net.

## Usage
### Searching for sentences
Example: `api/example/{search term}` 

Used to search the tatoeba database for sentences and get the individual words in the sentence and their individual readings.

The output for `api/example/草` would contain this json object among others:

```
{
	"english": "I give the cows hay, and midday's work is over.",
	"kanji": "牛に乾草をやって、昼の仕事はおわりです。",
	"kana": "うしにかんそうをやって、ひるのしごとはおわりです。",
	"seperatedByWordsOriginal": [
		"牛",
		"に",
		"乾草",
		"を",
		"やっ",
		"て",
		"、",
		"昼",
		"の",
		"仕事",
		"は",
		"おわり",
		"です",
		"。"
	],
	"seperatedByWordsKana": [
		"うし",
		"に",
		"かんそう",
		"を",
		"やっ",
		"て",
		"、",
		"ひる",
		"の",
		"しごと",
		"は",
		"おわり",
		"です",
		"。"
	]
```

### Converting words to kana
Example: `api/tokana/{words to convert}`

Used to get the individual words and readings from your own input.

Output example:
```
{
	"kanji": "この文章はAPIを試すために作りました。",
	"kana": "このぶんしょうはAPIをためすためにつくりました。",
	"seperatedByWordsOriginal": [
		"この",
		"文章",
		"は",
		"API",
		"を",
		"試す",
		"ため",
		"に",
		"作り",
		"まし",
		"た",
		"。"
	],
	"seperatedByWordsKana": [
		"この",
		"ぶんしょう",
		"は",
		"API",
		"を",
		"ためす",
		"ため",
		"に",
		"つくり",
		"まし",
		"た",
		"。"
	]
}
```

## Resources used

The Japanese sentences and English translations in this project were made by using the csv files hosted on the Tatoeba website:
https://tatoeba.org/eng/downloads

In this project, kana are generated by using the NMecab class library:
https://osdn.net/projects/nmecab/





