import React, { useState } from "react";
import {Card, Image} from "antd";

const SearchCarouselTitle = {
    marginTop: '10px',
    marginBottom: '10px',
    fontSize: '16px',
    fontFamily: 'assistant, sans-serif',
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
    alignContent: 'center',
    fontWeight: 'bolder',
    color: '#5c5c5c'
}

const ImageContainer = {
    marginBottom: '20px',
    marginTop: '10px',
}

const Images = {
    display: 'flex',
}

const SearchCarousel: React.FC = () => {
    return (
        <>
            <div style={ImageContainer}>
                <div style={SearchCarouselTitle}>
                <span>
                    <svg xmlns="http://www.w3.org/2000/svg" style={{color: '#8c8c8c'}} width="16" height="16"
                         fill="currentColor"
                         className="bi bi-transparency" viewBox="0 0 16 16">
                        <path
                            d="M0 6.5a6.5 6.5 0 0 1 12.346-2.846 6.5 6.5 0 1 1-8.691 8.691A6.5 6.5 0 0 1 0 6.5m5.144 6.358a5.5 5.5 0 1 0 7.714-7.714 6.5 6.5 0 0 1-7.714 7.714m-.733-1.269q.546.226 1.144.33l-1.474-1.474q.104.597.33 1.144m2.614.386a5.5 5.5 0 0 0 1.173-.242L4.374 7.91a6 6 0 0 0-.296 1.118zm2.157-.672q.446-.25.838-.576L5.418 6.126a6 6 0 0 0-.587.826zm1.545-1.284q.325-.39.576-.837L6.953 4.83a6 6 0 0 0-.827.587l4.6 4.602Zm1.006-1.822q.183-.562.242-1.172L9.028 4.078q-.58.096-1.118.296l3.823 3.824Zm.186-2.642a5.5 5.5 0 0 0-.33-1.144 5.5 5.5 0 0 0-1.144-.33z"/>
                    </svg>
                    &nbsp; &nbsp;
                    Images for Turkey
               </span>
                    <span style={{fontSize: '13px', borderBottom: '1px solid #6c6c6c'}}>
                   See more images
               </span>
                </div>
                <div style={Images}>
                    <Image
                        style={{borderRadius: '3px'}}
                        width={300}
                        height={100}
                        src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Flag_of_Turkey.svg/2000px-Flag_of_Turkey.svg.png"
                    />
                    &nbsp;
                    <Image
                        style={{borderRadius: '3px'}}
                        width={300}
                        height={100}
                        src="https://i.natgeofe.com/k/b4b412f8-fe02-482c-b6d6-e1b579cb7fff/turkey-istanbul.jpg?w=1084.125&h=609"
                    />
                    &nbsp;
                    <Image
                        style={{borderRadius: '3px'}}
                        width={300}
                        height={100}
                        src="https://fpc.org.uk/wp-content/uploads/2023/05/Turkish-elections.jpg"
                    />
                    <br />
                    &nbsp;
                    <Image
                        style={{borderRadius: '3px'}}
                        width={300}
                        height={100}
                        src="https://i.natgeofe.com/k/b4b412f8-fe02-482c-b6d6-e1b579cb7fff/turkey-istanbul.jpg?w=1084.125&h=609"

                    />
                    &nbsp;
                    <Image
                        style={{borderRadius: '3px'}}
                        width={300}
                        height={100}
                        src="https://fpc.org.uk/wp-content/uploads/2023/05/Turkish-elections.jpg"
                    />
                </div>
            </div>
        </>
    );
}

export default SearchCarousel;