## Bug Summary
> The name of the tray option contains one or more letters in the correct register
"—opEn 1.3 —close 1.2 —volume 1.5 —contract-size 10000 —leverage 10"

## Actual Result
> Error 

## Expected Result
		Commission 10	
		Margin 1500.0	
		Profit -75000.00	
----------------------------------------------------------------------------------		
## Bug Summary
> Commission value cannot be less than zero
"—open 1 —close 1.4 —volume 1.5 —contract-size 10000 —leverage 100 —commission-1"

## Actual Result
> Commission -1.5	
	Margin 1500.0	
	Profit 60000.00	

## Expected Result
> Error
----------------------------------------------------------------------------------	
## Bug Summary
> bad calculation from file when default value of tray type t2.json
{
  "openPrice": 1.5.
  "closePrice": 1.6.
  volume: 1.5.
  "contractSize": 100,000,
  leverage: 100,
  "commission": 10
}

## Actual Result
> Commission 0	
	Margin 1500.0	
	Profit 15000.00		

## Expected Result
> Commission 15.0	
	Margin 1500.0	
	Profit 15000.00
----------------------------------------------------------------------------------			
## Bug Summary
> when someone of options is unexists, softwaremm doesn't check requried options - example unexists 'leverage'
 —open 1 —close 1.4 —volume 1.5 —contract-size 10000 —commission -1

## Actual Result
> leverage is unexists.		

## Expected Result
Trade parsed from 'Args'
Several errors occured:
Attempted to divide by zero. (System.DivideByZeroException)
----------------------------------------------------------------------------------		
## Bug Summary
> unhandled exception when directory wasn't found
