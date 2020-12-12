﻿define(['knockout'], (ko) => {
    return function () {
        //console.log(window.movieValue)
        console.log(window.personToMoviePage)

        let titleData = ko.observableArray([{}])
        const url = 'http://localhost:5001/api/title/';

        fetch(url + window.movieValue)
            .then((response) => {
                return response.json()
            })
            .then((data) => {
                titleData(data)
                console.log(titleData())
            }).catch((err) => {
        })
        
       

        
        
        fetch(url + window.personToMoviePage)
            .then((response) => {
                return response.json()
            })
            .then((data) => {
                titleData(data.titleDto)
            }).catch((err) => {
        })
        
        return {
            titleData
        };
    }
});