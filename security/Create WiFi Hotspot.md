# Create WiFi Hotspot in Windows 7
> You must open cmd.exe with Admin priviledges

## Create a hotspot
``` batch
netsh wlan set hostednetwork mode=allow ssid=SSID_NAME key=KEY
```

## Start the HotSpot
``` batch
netsh wlan start hosted network
```

## Stop the Hostspot
``` batch
netsh wlan stop hostednetwork
```
