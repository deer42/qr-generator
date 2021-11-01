# qr-generator

[![.NET](https://github.com/deer42/qr-generator/actions/workflows/dotnet.yml/badge.svg?branch=develop)](https://github.com/deer42/qr-generator/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/deer42/qr-generator/branch/develop/graph/badge.svg?token=BZFYH4UZKW)](https://codecov.io/gh/deer42/qr-generator)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=deer42_qr-generator&metric=coverage)](https://sonarcloud.io/summary/new_code?id=deer42_qr-generator)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=deer42_qr-generator&metric=bugs)](https://sonarcloud.io/summary/new_code?id=deer42_qr-generator)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=deer42_qr-generator&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=deer42_qr-generator)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=deer42_qr-generator&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=deer42_qr-generator)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=deer42_qr-generator&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=deer42_qr-generator)

## How to use

```cmd
QrGenerator.Cli.exe -s "testdata.txt" -o "C:\temp\qrcodes" -t "JPG" -p 16 -h -x
```

## Parameters

```
-s, --sourceFilePath              Required. Sets the path to the source file

-o, --destinationDirectoryPath    Required. Sets the path to the destination files directory

-t, --destinationFileType         (Default: JPG) Sets the destination file type. Allowed options: JPG, PNG, BMP

-p, --pixelsPerModule             (Default: 8) Sets the size of each module in pixels

-h, --hasHeader                   (Default: false) Use this to use headers

--skipRows                        (Default: 0) Use this to skip the first x lines

-f, --format                      (Default: k:v/n) Sets the pattern to format the data

-x, --turbo                       Try to export in parallel

--help                            Display this help screen.

--version                         Display version information.
```

## Supported source file types

- xls
- xlsx
- csv
- txt

## Supported qr image file types

- bmp
- png
- jpg

## Build

Run this command to build and publish the application in 'publish' folder in the root of this repository.

```cmd
dotnet publish -p:PublishProfile=FolderProfile
```
