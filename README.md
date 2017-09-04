## use

```bash
CSVRearrange.exe --config=config.json --maps=maps.json --input=input.txt --output=output.txt
```

## config.json
```js
{
    "input": {
        "encoding": "Windows-1252"
    },
    "output": {
        "columns": 51,
        "encoding": "utf-8",
        "separator": ";"
    }
}
```

## maps.json
```js
[
    {
        /* input column 2 goes to output column 0 */
        "source": 2,
        "target": 0
    },
    {
        /* input column 1 goes to output column 1 */
        "source": 1,
        "target": 1
    },
    {
        /* input column 0 goes to output column 3 */
        "source": 0,
        "target": 3
    },
    {
        "source": 10,
        "target": 10
    }
]
```