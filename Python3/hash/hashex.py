import hashlib

data = "Hello, World!".encode()

# MD5
print(hashlib.md5(data).hexdigest())

# SHA1
print(hashlib.sha1(data).hexdigest())

# SHA224
print(hashlib.sha224(data).hexdigest())

# SHA256
print(hashlib.sha256(data).hexdigest())

# SHA384
print(hashlib.sha384(data).hexdigest())

# SHA512
print(hashlib.sha512(data).hexdigest())

# SHA3_224
print(hashlib.sha3_224(data).hexdigest())

# SHA3_256
print(hashlib.sha3_256(data).hexdigest())

# SHA3_384
print(hashlib.sha3_384(data).hexdigest())

# SHA3_512
print(hashlib.sha3_512(data).hexdigest())

# BLAKE2b
print(hashlib.blake2b(data).hexdigest())

# BLAKE2s
print(hashlib.blake2s(data).hexdigest())
