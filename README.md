AWS Lambda 開発用ワークスペース
========================================================================

## 概要

C# AWS Lambdaの雛形やSnippetの管理のためのもの

何か作るときは

```
make func FUCN=XXX
```

で作成して、実装は作成したディレクトリで行う。<br>
作成したFUNCのディレクトリは別リポジトリ管理する。

## hello world

```
make func FUCN=XXX
cd XXX
make all
```

ここまでの状態では、ローカル実行/テスト

```
make deploy
```

でLambdaに実際に生成される。

### リージョン指定について

デフォで ap-northeast-1, 変更するには CreateLamnbndaToolsDefaults.php を弄る。

### ロールについて

Lambdaのロールはいい感じの名前で作ってあるものを取得する前提なので、事前にLambda*****という名前で作っておくこと。
（Lambdaへの付与許可を与えておくのをわすれずに！！）

名前指定については、Makefile.inで ROLE_ARN 変数にシェル芸で突っ込んでいる。

```
ROLE_ARN  ?= $(shell aws iam list-roles | jq '.[]' | jq 'map(select(.RoleName | startswith("Lambda")))' | jq '.[0].Arn')
```

こんな感じ。

