# Hackerthon2021

## 환경설정
### 1. rpi4 환경설정
http://download.tizen.org/releases/milestone/tizen/unified/tizen-unified_20210513.3/images/standard/

### 2. rpi4 바이너리 설치
 ./tizenspk_burn_sdcard_rpi.sh -b ./tizen-unified_20200326.1_iot-boot-armv7l-rpi3.tar.gz -p ./tizen-unified_20200326.1_iot-headed-3parts-armv7l-rpi3.tar.gz

 // (단, 스크립트 실행 후 Please type device node of usb 항목에서 꼭 본인의 usb 하드를 적어주세요. (e.g. sdc))


### 3. package 설치
#### dali package
 dali_packages_0715.zip 압축 해제
 
 rpm -Uh --force --nodeps *.rpm
 
#### tizenfx package
  tizenfx-16468 ver 패키지 설치 (tizenfx_packages.zip)

  1) AOT Disable(ni.dll 파일 삭제)

     find / -name '*.ni.dll' -exec rm {} \; 
     find / -name '*.ni.exe' -exec rm {} \;

  2) tizenfx rpm 설치

     rpm -Uh --force --nodeps *.rpm

  3) AOT Enable

     dotnettool --ni-system
     
  4) sync & reboot




