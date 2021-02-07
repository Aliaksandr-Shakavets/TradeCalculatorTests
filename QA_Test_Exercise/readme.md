# Description

This apps calculates profit, used margin and commissions for predefined trade properties.
`.NET 4.5.2` required to run the app.

# Definitions

## Each trade consists of

- Open price (must be `>0`)
- Close price (`>0`)
- Volume (`>0` means `Buy`, `<0` means `Sell` )
- Contract size (`>0`)
- Leverage (`>0`)
- Commission (`>=0`)
- Commission type (`PerLot` / `PerTrade`)

## Calculation results consist of

- Profit
- Margin (`>0`)
- Commission (`>=0`)

## Calculation

```
Profit = (ClosePrice - OpenPrice) * Volume * ContractSize
Margin = Volume * ContractSize / Leverage
Commission (PerLot) = Commission * Volume
Commission (PerTrade) = Commission * 1
```

## Error handling

If trade definitions contain invalid data the app will write all the errors it finds either to the console or files.
Errors include human-readable messages.

# How to use

Launch `TradeCalculator.exe --help` for full command line argument format.

## Input

### Files

Accepts one or more `JSON` files, each represents a trade. See `/Samples` folder to examine the input file format.
Sample: `TradeCalculator.exe -f f1.json f2.json f3.json`

### Command line

Only one trade at a time. All trade properties are defined in the command line.
Sample: `TradeCalculator.exe --open 1.1 --close 1.2 --volume 1.5 --contract-size 100000 --leverage 10`

## Output

### Console

Sample: `TradeCalculator.exe -o Console`

### Files

Saves results next to the source files.
Sample: `TradeCalculator.exe -o File`