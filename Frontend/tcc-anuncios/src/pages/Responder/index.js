import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css';
import '../Responder/style.css';

import Logo from '../../assets/image/Capturar.PNG';

import anuncioAPI from '../../services/anuncioAPI';
import { toast } from "react-toastify";
const api = new anuncioAPI();


export default function Responder(props){
    const navegacao = useHistory();

    const [infos, setInfos] = useState(props.location.state);
    const [resposta, setResposta] = useState('');
    console.log(infos)
    
    const responder = async () => {
        try{
            const model = {
                Texto: resposta,
                IdUsuarioRespondedor: infos.infos.infos.idUsuario,
                IdPerguntaResposta: infos.x.idPerguntaResposta
            }
            const resp = await api.responder(model);
            navegacao.goBack();
        }
        catch (e){
            toast.error(e.response)
        }
    }

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname:"/Home", state: infos.infos.infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div> 

                <div className="barraPesquisa hihi">
                    <Link to={{pathname:"/Home", state: infos.infos.infos}}>Fazer novas consultas</Link>
                </div>
                
                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos.infos.infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusAnuncios", state: infos.infos.infos }}>Meus Anuncios</Link>
                    <Link class="hihi meio" to={{ pathname: "/MeusFavoritos", state: infos.infos.infos }}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to={{pathname: "/Anunciar", state: infos.infos.infos}}><button class="botao">Anunciar</button></Link>
                </div>
            </div>

            <div className="criolo">
                <input className="cali" value={resposta} onChange={e => setResposta(e.target.value)} type="text" placeholder="Digite a resposta aqui"></input>
                <button className="calix" onClick={() => responder()}>Responder</button>
            </div>
        </div>
    )
}