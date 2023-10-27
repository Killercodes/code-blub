: Create WiFi Hotspot in Windows 7
: You must open cmd.exe with Admin priviledges

: Create a hotspot
netsh wlan set hostednetwork mode=allow ssid=SSID_NAME key=KEY


: Start the HotSpot
netsh wlan start hosted network

: Stop the Hostspot
netsh wlan stop hostednetwork

