//
// Created by Yasin Özkaya on 19.12.2023.
//

#ifndef ARTADO_REACT_REQ_H
#define ARTADO_REACT_REQ_H

#include <curl/curl.h>
#include <iostream>
#include <string>

static size_t WriteCallBack(void *contents, size_t size, size_t nmemb, void *userp) {
    ((std::string *) userp)->append((char *) contents, size * nmemb);
    return size * nmemb;
}


#endif
