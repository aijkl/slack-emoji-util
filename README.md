# slack-emoji-util

clientId
clientSecret
callBackUrl
は各自の環境に合った値を入力してください
https://github.com/aijkl/slack-emoji-util/blob/a315c9f432532ab84e2b99ffb19610b66076428b/EmojiToggle/appsettings.json#L1-L5

### 認証

```jsx
./SlackUtil/SlackUtil.exe sigin
```

キャッシュファイルにトークンを保存する仕様も考えましたが、トークンを標準出力で出力することにしました、各コマンドの引数でトークンをもらってAPIに流します

### プロフィール更新

```jsx
./SlackUtil/SlackUtil.exe profile <TOKEN> --emoji :勤務中:
```

勤務中という絵文字を付けます、すでにステータスメッセージがある場合は上書きされません

```jsx
./SlackUtil/SlackUtil.exe profile <TOKEN> --emoji :勤務中: --status 17時から勤務中
```

これは勤務中にして何時から17時から勤務中であることを表示します


```jsx
./SlackUtil/SlackUtil.exe clear-profile <TOKEN>
```
これはプロフィールをクリアします、つまり退勤時に使います

## シェルスクリプトに書く

### 出勤
`"$(date +'%-H時から勤務中')"`で動的に書いてみます
```jsx
curl -X POST [http://mkkintai.herokuapp.com/api/v1/timekeepers](http://mkkintai.herokuapp.com/api/v1/timekeepers) -d "[email=hogehogheo@mksc.jp](mailto:email=hogehoge@mksc.jp)&password="
./SlackUtil/SlackUtil.exe profile xoxp-2551974910-???????????? --emoji :勤務中:  --status "$(date +'%-H時から勤務中')"
```

### 退勤
```
curl -X PATCH  http://mkkintai.herokuapp.com/api/v1/timekeepers -d "email=@mksc.jp&password=" 
./SlackUtil/SlackUtil.exe clear-profile <TOKEN>
```
