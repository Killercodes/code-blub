#!/bin/python
import os

print("~: SysUpdate 1.0 :~")
print("====================")

print("Updating..")
os.system("apt-get update")

print("Upgrading..")
os.system("apt-get upgrade")

print("SysUpdate comepleted..")

