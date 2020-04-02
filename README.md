# IRIProductSelector

## Installation

Clone the repository in your local machine

Go to the repository location and run the following commands

```bash
cd IRIProductSelector.App

dotnet build -c Release  IRIProductSelector.App.csproj

cd bin/Release/netcoreapp3.1/

dotnet IRIProductSelector.App.dll
```

## Results

The results will be comma separated list of latest distinct Code types for each Product

```bash
ProductId,ProductName,CodeType,Code
18886,FISH OIL,Barcode,93482745
18886,FISH OIL,Woolworths Reference Number,017E9562042C3E9F0E1D200A8C915052
49183,CAN OF BEER,Woolworths Reference Number,107AD29285EE3B8422E505E397D4F128
49183,CAN OF BEER,Barcode,9310876029984
49183,CAN OF BEER,LIQUOR BARON INTERNAL CODE,15107
49183,CAN OF BEER,RITCHIES LIQUOR STORE-LEVEL CODE,1193000505521
49183,CAN OF BEER,Liquor Baron (Brown Forman) RefNo,U18072
68566,CARAMELLO DESSERT,METCASH REFNO,120355
212855,LONG GRAIN RICE,Barcode,9300633350079
212855,LONG GRAIN RICE,Woolworths Reference Number,1B805DC15FE871DADFD5225772CFDE9F
212855,LONG GRAIN RICE,NZ Barcode,9300633350079-35007
217832,LAVENDER AIR FRESHENER REFILL,Barcode,46500008481
217832,LAVENDER AIR FRESHENER REFILL,Woolworths Reference Number,9DE1FBCC6C5162DE83FEE28B528438C0
218553,EGGS,Barcode,9310970114500
346575,POTPOURRI,Barcode,9300636006225
346575,POTPOURRI,METCASH REFNO,446757
346575,POTPOURRI,FALWHS,74527
346575,POTPOURRI,Woolworths Reference Number,35ACD97DC37D68447AFA6E7694745598
398698,MACKEREL TOMATO SAUCE,Barcode,66613247027
960724,BOOK,Barcode,9780732279769
1075959,PINOT NOIR WINE,Barcode,9339339000377
1075959,PINOT NOIR WINE,Liquor Baron (Brown Forman) RefNo,S9260
1075959,PINOT NOIR WINE,LIQUOR BARON INTERNAL CODE,33586

```
Press Enter to exit

## Tests

In the solution root directory run the following commands

```bash
cd IRIProductSelector.Data.Tests

dotnet build -c Release IRIProductSelector.Data.Tests.csproj

dotnet test bin/Release/netcoreapp3.1/IRIProductSelector.Data.Tests.dll

```

## Test results

```bash
Test Run Successful.
Total tests: 13
     Passed: 13
 Total time: 1.0068 Seconds
```

